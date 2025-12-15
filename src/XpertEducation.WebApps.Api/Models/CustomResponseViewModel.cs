using System.Text.Json.Serialization;

namespace XpertEducation.WebApps.Api.Models;

public class CustomResponseViewModel
{
    [JsonPropertyName("data")]
    public object Data { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }
}
