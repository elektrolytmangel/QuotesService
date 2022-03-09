using System.Text.Json.Serialization;

namespace QuotesService.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuoteType
    {
        FAVORITE = 1,
        FAMOUSE = 2, 
        SOMEONE_OTHERS_FAVORITE = 3,
    }
}