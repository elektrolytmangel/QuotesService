
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace QuotesService.Model
{
    public class Quote
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public string? Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string AdditionalInformation { get; set; }

        public QuoteType Type { get; set; }
    }
}