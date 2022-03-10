using Microsoft.AspNetCore.Mvc;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using QuotesService.Persistence;

namespace QuotesService.Controllers
{
    public class RandomQuotesController : ControllerBase
    {
        private readonly QuotesRandomizer randomizer;
        private readonly IEnumerable<QuotesFileRepository> repositories;

        public RandomQuotesController(QuotesRandomizer randomizer, IEnumerable<QuotesFileRepository> repositories)
        {
            this.randomizer = randomizer;
            this.repositories = repositories;
        }

        [HttpGet]
        [Route("{count}")]
        public IActionResult RandomQuotes(int count)
        {
            try
            {
                var allQuotes = this.GetAllQuotes();
                var result = this.randomizer.SelectRandom(count, allQuotes);

                return new OkObjectResult(result);
            }
            catch(ArgumentException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IList<Quote> GetAllQuotes()
        {
            var result = new List<Quote>();
            foreach (var repo in repositories)
            {
                result.AddRange(repo.ReadQuotes());
            }

            return result;
        }
    }
}
