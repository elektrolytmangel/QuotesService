namespace QuotesService.Model
{
    public class Quote
    {
        public Quote(Guid id, string content, string author, string additionalInformation)
        {
            Id = id;
            Content = content;
            Author = author;
            AdditionalInformation = additionalInformation;
        }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
