using Newtonsoft.Json;

namespace GKFreecam.Metadata
{
    public class JSONConfig
    {
        [JsonProperty("sensitivity")]
        public int Sensitivity = 1;

        [JsonProperty("activatorkey")]
        public string ActivatorKey = "[";

        [JsonProperty("hidecamkey")]
        public string HideCamKey = "]";
    }
}
