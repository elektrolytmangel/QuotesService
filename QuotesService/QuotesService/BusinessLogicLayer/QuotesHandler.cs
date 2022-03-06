using QuotesService.Model;

namespace QuotesService.BusinessLogicLayer
{
    public class QuotesHandler
    {
        public Quote Add(Quote quote)
        {
            quote.Id = Guid.NewGuid();


            return quote;
        }

        public Quote Update(Quote quote)
        {
            

            return quote;
        }
    }
}