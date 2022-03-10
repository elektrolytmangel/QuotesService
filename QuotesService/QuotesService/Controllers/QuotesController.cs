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
        private readonly QuotesHandler qutoesHandler;
        private readonly IEnumerable<QuotesFileRepository> repositories;

        public QuotesController(QuotesHandler quotesHandler, IEnumerable<QuotesFileRepository> repositories) // will be initialized for each request
        {
            this.qutoesHandler = quotesHandler;
            this.repositories = repositories;
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
            foreach(var repo in repositories)
            {
                result.AddRange(repo.ReadQuotes());
            }

            return result;
        }

        private void WriteQuotes(IList<Quote> quotes)
        {
            foreach (var repo in repositories)
            {
                repo.WriteQuotes(quotes);
            }
        }
    }
}