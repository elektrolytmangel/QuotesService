using Microsoft.AspNetCore.Mvc;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using QuotesService.Persistence;

namespace QuotesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly string favoriteQuotesPath = @"C:\Temp\MyFavoriteQuotes.json";
        private readonly string famouseQuotesPath = @"C:\Temp\FamouseQuotes.json";
        private readonly string othersFavoriteQuotesPath = @"C:\Temp\OthersFavoriteQuotes.json";

        private readonly QuotesFileRepository favoriteRepository;
        private readonly QuotesFileRepository famouseRepository;
        private readonly QuotesFileRepository othersRepository;
        private readonly QuotesHandler qutoesHandler;

        public QuotesController() // will be initialized for each request
        {
            favoriteRepository = new QuotesFileRepository(favoriteQuotesPath, QuoteType.FAVORITE);
            famouseRepository = new QuotesFileRepository(famouseQuotesPath, QuoteType.FAMOUSE);
            othersRepository= new QuotesFileRepository(othersFavoriteQuotesPath, QuoteType.SOMEONE_OTHERS_FAVORITE);
            qutoesHandler = new QuotesHandler();

        }

        [HttpPost]
        public IActionResult Create(Quote quote)
        {
            try
            {
                quote.Id = Guid.Empty; // ensure there is no id already set

                var allQuotes = this.GetAllQuotes();
                var result = qutoesHandler.AddOrUpdate(quote, allQuotes);
                this.WriteQuotes(allQuotes);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Read(Guid id)
        {
            try
            {
                var allQuotes = this.GetAllQuotes();
                var result = qutoesHandler.Get(id, allQuotes);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            try
            {
                var allQuotes = this.GetAllQuotes();
                var result = qutoesHandler.Get(Guid.Empty, allQuotes);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, Quote quote)
        {
            try
            {
                quote.Id = id;

                var allQuotes = this.GetAllQuotes();
                var result = qutoesHandler.AddOrUpdate(quote, allQuotes);
                this.WriteQuotes(allQuotes);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var allQuotes = this.GetAllQuotes();
                var result = qutoesHandler.DeleteQuote(id, allQuotes);
                this.WriteQuotes(allQuotes);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IList<Quote> GetAllQuotes()
        {
            var result = new List<Quote>();
            result.AddRange(this.favoriteRepository.ReadQuotes());
            result.AddRange(this.famouseRepository.ReadQuotes());
            result.AddRange(this.othersRepository.ReadQuotes());

            return result;
        }

        private void WriteQuotes(IList<Quote> quotes)
        {
            this.favoriteRepository.WriteQuotes(quotes);
            this.famouseRepository.WriteQuotes(quotes);
            this.othersRepository.WriteQuotes(quotes);
        }
    }
}