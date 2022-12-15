using QuotesService.Model;

namespace QuotesService.BusinessLogicLayer
{
    public class QuotesHandler
    {
        public IList<Quote> Get(string id, IList<Quote> allQuotes)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return allQuotes.Where(x => x.Id == id).ToList();
            }
            else
            {
                return allQuotes;
            }
        }

        public Quote AddOrUpdate(Quote quote, IList<Quote> allQuotes)
        {
            if (quote == null)
            {
                throw new ArgumentNullException(nameof(quote));
            }

            if (string.IsNullOrEmpty(quote.Id))
            {
                quote.Id = Guid.NewGuid().ToString();
                allQuotes.Add(quote);
            }
            else
            {
                var updateQuotes = allQuotes.Where(q => q.Id != quote.Id).ToList();
                updateQuotes.Add(quote);

                allQuotes = updateQuotes;
            }

            return quote;
        }

        public Quote DeleteQuote(string id, IList<Quote> allQuotes)
        {
            var quoteToDelete = allQuotes.SingleOrDefault(q => q.Id == id);
            if (quoteToDelete != null && allQuotes.Remove(quoteToDelete))
            {
                return quoteToDelete;
            }

            throw new Exception("Quote not found.");
        }
    }
}