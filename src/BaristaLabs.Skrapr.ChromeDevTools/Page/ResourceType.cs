namespace BaristaLabs.Skrapr.ChromeDevTools.Page
{
    using Newtonsoft.Json;

    /// <summary>
    /// Resource type as it was perceived by the rendering engine.
    /// </summary>
    [JsonConverter(typeof(StringClassConverter))]
    public sealed class ResourceType
    {
        private string m_value;
        
        public ResourceType(string value)
        {
            m_value = value;
        }

        public override string ToString()
        {
            return m_value;
        }

        public override bool Equals(object obj)
        {
            return m_value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }

    
        public static ResourceType Document = new ResourceType("Document");
    
        public static ResourceType Stylesheet = new ResourceType("Stylesheet");
    
        public static ResourceType Image = new ResourceType("Image");
    
        public static ResourceType Media = new ResourceType("Media");
    
        public static ResourceType Font = new ResourceType("Font");
    
        public static ResourceType Script = new ResourceType("Script");
    
        public static ResourceType TextTrack = new ResourceType("TextTrack");
    
        public static ResourceType XHR = new ResourceType("XHR");
    
        public static ResourceType Fetch = new ResourceType("Fetch");
    
        public static ResourceType EventSource = new ResourceType("EventSource");
    
        public static ResourceType WebSocket = new ResourceType("WebSocket");
    
        public static ResourceType Manifest = new ResourceType("Manifest");
    
        public static ResourceType Other = new ResourceType("Other");
    
    }
}