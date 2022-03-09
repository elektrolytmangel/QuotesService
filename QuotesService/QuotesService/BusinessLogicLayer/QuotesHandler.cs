using QuotesService.Model;

namespace QuotesService.BusinessLogicLayer
{
    public class QuotesHandler
    {
        public IList<Quote> Get(Guid id, IList<Quote> allQuotes)
        {
            if (id != Guid.Empty)
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

            return quote;
        }

        public Quote DeleteQuote(Guid id, IList<Quote> allQuotes)
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