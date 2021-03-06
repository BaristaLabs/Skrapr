namespace BaristaLabs.Skrapr.ChromeDevTools.Page
{
    using Newtonsoft.Json;

    /// <summary>
    /// Capture page screenshot.
    /// </summary>
    public sealed class CaptureScreenshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.captureScreenshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Image compression format (defaults to png).
        /// </summary>
        [JsonProperty("format", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Format
        {
            get;
            set;
        }
        /// <summary>
        /// Compression quality from range [0..100] (jpeg only).
        /// </summary>
        [JsonProperty("quality", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Quality
        {
            get;
            set;
        }
    }

    public sealed class CaptureScreenshotCommandResponse : ICommandResponse<CaptureScreenshotCommand>
    {
        /// <summary>
        /// Base64-encoded image data.
        ///</summary>
        [JsonProperty("data")]
        public string Data
        {
            get;
            set;
        }
    }
}