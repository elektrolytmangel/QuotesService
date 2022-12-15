using Microsoft.AspNetCore.Mvc;
using QuotesService.BusinessLogicLayer;
using QuotesService.Persistence;

namespace QuotesService.Controllers
{
    public class RandomQuotesController : ControllerBase
    {
        private readonly QuotesRandomizer randomizer;
        private readonly QuotesCosmosRepository repository;

        public RandomQuotesController(QuotesRandomizer randomizer, QuotesCosmosRepository repository)
        {
            this.randomizer = randomizer;
            this.repository = repository;
        }

        [HttpGet]
        [Route("{count}")]
        public async Task<ActionResult> RandomQuotes(int count)
        {
            try
            {
                var allQuotes = await repository.GetItemsAsync();
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
    }
}
