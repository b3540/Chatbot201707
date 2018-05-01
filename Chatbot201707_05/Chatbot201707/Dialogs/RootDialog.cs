﻿using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using Microsoft.Bot.Builder.FormFlow;

namespace Chatbot201707.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private List<string> menuList = new List<string>() { "ランチコース", "カレー", "ドリンク", "デザート", "終了" };

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(HelloMessage);
            return Task.CompletedTask;
        }

        private async Task HelloMessage(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("いらっしゃいませ！ご注文を伺います。");
            MenuMessage(context);
        }

        private void MenuMessage(IDialogContext context)
        {
            PromptDialog.Choice(context, SelectDialog, menuList, "ランチメニューをお選びください。");
        }

        private async Task SelectDialog(IDialogContext context, IAwaitable<object> result)
        {
            var selectedMenu = await result;
            switch (selectedMenu)
            {
                case "ランチコース":
                    context.Call(new LunchDialog(), LunchResumeAfterDialog);
                    break;
                case "カレー":
                    context.Call(new CurryDialog(), CurryResumeAfterDialog);
                    break;
                case "ドリンク":
                    context.Call(new DrinkDialog(), DrinkResumeAfterDialog);
                    break;
                case "デザート":
                    context.Call(new DessertDialog(), DessertResumeAfterDialog);
                    break;
                case "終了":
                    await context.PostAsync("ご注文を承りました。");
                    context.Wait(HelloMessage);
                    break;
            }
        }

        private async Task LunchResumeAfterDialog(IDialogContext context, IAwaitable<string> result)
        {
            var lunch = await result;
            await context.PostAsync($"ランチコースは　{lunch}　ですね。");
            MenuMessage(context);
        }
        
        private async Task CurryResumeAfterDialog(IDialogContext context, IAwaitable<CurryFormQuery> result)
        {
            var curry = await result;
            var topping = "";

            for (int i = 0; i < curry.Topping.Count; i++)
            {
                topping += "　" + curry.Topping[i];
            }

            await context.PostAsync($@"カレーは {curry.Curry.ToString()}　ですね。

ライスは {curry.Rice.ToString()}　ですね。

サイズは {curry.Size.ToString()}　ですね。

トッピングは {topping}　ですね。

");
            MenuMessage(context);
        }

        private async Task DrinkResumeAfterDialog(IDialogContext context, IAwaitable<string> result)
        {
            var drink = await result;
            await context.PostAsync($"お飲み物は　{drink}　ですね。");
            MenuMessage(context);
        }

        private async Task DessertResumeAfterDialog(IDialogContext context, IAwaitable<string> result)
        {
            var dessert = await result;
            await context.PostAsync($"デザートは　{dessert}　ですね。");
            MenuMessage(context);
        }
    }
}