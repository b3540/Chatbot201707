// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bot.Connector
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class BotStateDataResult
    {
        /// <summary>
        /// Initializes a new instance of the BotStateDataResult class.
        /// </summary>
        public BotStateDataResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BotStateDataResult class.
        /// </summary>
        public BotStateDataResult(IList<BotStateData> botStateData = default(IList<BotStateData>), string continuationToken = default(string))
        {
            BotStateData = botStateData;
            ContinuationToken = continuationToken;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "botStateData")]
        public IList<BotStateData> BotStateData { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "continuationToken")]
        public string ContinuationToken { get; set; }

    }
}
