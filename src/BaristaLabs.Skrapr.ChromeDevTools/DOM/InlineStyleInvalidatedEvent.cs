namespace BaristaLabs.Skrapr.ChromeDevTools.DOM
{
    using Newtonsoft.Json;

    /// <summary>
    /// Fired when &lt;code&gt;Element&lt;/code&gt;'s inline style is modified via a CSS property modification.
    /// </summary>
    public sealed class InlineStyleInvalidatedEvent : IEvent
    {
        /// <summary>
        /// Ids of the nodes for which the inline styles have been invalidated.
        /// </summary>
        [JsonProperty("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}