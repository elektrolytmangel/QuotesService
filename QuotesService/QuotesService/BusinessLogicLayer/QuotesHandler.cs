using QuotesService.Model;
using System.Text.Json;

namespace QuotesService.BusinessLogicLayer
{
    public class QuotesHandler
    {
        private static object lockObject = new object();
        private readonly string favoriteQuotesPath = @"C:\Temp\MyFavoriteQuotes.json";
        private readonly string famouseQuotesPath = @"C:\Temp\FamouseQuotes.json";
        private readonly string othersFavoriteQuotesPath = @"C:\Temp\OthersFavoriteQuotes.json";

        public QuotesHandler()
        {
            lock (lockObject)
            {
                if (!File.Exists(favoriteQuotesPath))
                {
                    File.Create(favoriteQuotesPath).Dispose();
                }

                if (!File.Exists(famouseQuotesPath))
                {
                    File.Create(famouseQuotesPath).Dispose();
                }

                if (!File.Exists(othersFavoriteQuotesPath))
                {
                    File.Create(othersFavoriteQuotesPath).Dispose();
                }
            }
        }

        public IList<Quote> Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                return this.ReadQuotes().Where(x => x.Id == id).ToList();
            }
            else
            {
                return this.ReadQuotes();
            }
        }

        public Quote AddOrUpdate(Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException(nameof(quote));
            }

            var allQuotes = this.ReadQuotes();

            if (quote.Id == Guid.Empty)
            {
                quote.Id = Guid.NewGuid();
                allQuotes.Add(quote);
            }
            else
            {
                var updateQuotes = allQuotes.Where(q => q.Id != quote.Id).ToList();
                updateQuotes.Add(quote);

                allQuotes = updateQuotes;
            }

            this.WriteQuotes(allQuotes);
            return quote;
        }

        public Quote DeleteQuote(Guid id)
        {
            var allQuotes = this.ReadQuotes();

            var quoteToDelete = allQuotes.SingleOrDefault(q => q.Id == id);
            if (quoteToDelete != null && allQuotes.Remove(quoteToDelete))
            {
                this.WriteQuotes(allQuotes);
                return quoteToDelete;
            }

            throw new Exception("Quote not found.");
        }

        private IList<Quote> ReadQuotes()
        {
            lock (lockObject)
            {
                var result1 = File.ReadAllText(favoriteQuotesPath);
                var result2 = File.ReadAllText(famouseQuotesPath);
                var result3 = File.ReadAllText(othersFavoriteQuotesPath);

                var resultList = new List<Quote>();

                if (!string.IsNullOrEmpty(result1))
                {
                    resultList.AddRange(JsonSerializer.Deserialize<List<Quote>>(result1));
                }

                if (!string.IsNullOrEmpty(result2))
                {
                    resultList.AddRange(JsonSerializer.Deserialize<List<Quote>>(result2));
                }

                if (!string.IsNullOrEmpty(result3))
                {
                    resultList.AddRange(JsonSerializer.Deserialize<List<Quote>>(result3));
                }

                return resultList;
            }
        }

        private void WriteQuotes(IList<Quote> quotes)
        {
            lock (lockObject)
            {
                var favoriteQuotes = quotes.Where(q => q.Type == QuoteType.FAVORITE);
                var famouseQuotes = quotes.Where(q => q.Type == QuoteType.FAMOUSE);
                var othersFavoriteQuotes = quotes.Where(q => q.Type == QuoteType.SOMEONE_OTHERS_FAVORITE);

                var resultFavorite = JsonSerializer.Serialize(favoriteQuotes);
                var resultFamouse = JsonSerializer.Serialize(famouseQuotes);
                var resultOthers = JsonSerializer.Serialize(othersFavoriteQuotes);

                File.WriteAllText(favoriteQuotesPath, resultFavorite);
                File.WriteAllText(famouseQuotesPath, resultFamouse);
                File.WriteAllText(othersFavoriteQuotesPath, resultOthers);
            }
        }
    }
}