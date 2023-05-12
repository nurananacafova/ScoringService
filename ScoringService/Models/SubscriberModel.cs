using System.Globalization;
using Newtonsoft.Json;

namespace ScoringService;

public class SubscriberModel
{
    public int id { get; set; }
    public string? language { get; set; }
    public string? email { get; set; }
    [JsonProperty("registration_date")] public DateTime registration_date { get; set; }
}