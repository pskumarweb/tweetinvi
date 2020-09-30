using Newtonsoft.Json;

namespace Tweetinvi.Models.V2
{
    public class MediaOrganicMetricsDTO : MediaMetricsDTO
    {
        [JsonProperty("view_count")] public int view_count { get; set; }
    }
}