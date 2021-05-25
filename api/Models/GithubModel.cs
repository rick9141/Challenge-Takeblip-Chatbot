using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class GithubModel
{
    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonIgnore]
    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonIgnore]
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
}