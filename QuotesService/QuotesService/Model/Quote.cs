using Newtonsoft.Json;

namespace QuotesService.Model
{
    public class Quote : IEquatable<Quote>
    {
        public Quote(string id, string content, string author, string additionalInformation)
        {
            Id = id;
            Content = content;
            Author = author;
            AdditionalInformation = additionalInformation;
        }

        public Quote(string id)
        {
            this.Id = id;
        }

        public Quote() { }

        [JsonProperty("id")]
        public string Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string AdditionalInformation { get; set; }

        public QuoteType Type { get; set; }

        public bool Equals(Quote? other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}
