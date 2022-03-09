using Microsoft.AspNetCore.Mvc;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using QuotesService.Persistence;

namespace QuotesService.Controllers
{
    public class RandomQuotesController : ControllerBase
    {
        private readonly string favoriteQuotesPath = @"C:\Temp\MyFavoriteQuotes.json";
        private readonly string famouseQuotesPath = @"C:\Temp\FamouseQuotes.json";
        private readonly string othersFavoriteQuotesPath = @"C:\Temp\OthersFavoriteQuotes.json";

        private readonly QuotesFileRepository favoriteRepository;
        private readonly QuotesFileRepository famouseRepository;
        private readonly QuotesFileRepository othersRepository;

        public RandomQuotesController()
        {
            favoriteRepository = new QuotesFileRepository(favoriteQuotesPath, QuoteType.FAVORITE);
            famouseRepository = new QuotesFileRepository(famouseQuotesPath, QuoteType.FAMOUSE);
            othersRepository = new QuotesFileRepository(othersFavoriteQuotesPath, QuoteType.SOMEONE_OTHERS_FAVORITE);
        }

        [HttpGet]
        [Route("{count}")]
        public IActionResult RandomQuotes(int count)
        {
            try
            {
                var randomizer = new QuotesRandomizer();
                var allQuotes = this.GetAllQuotes();
                var result = randomizer.SelectRandom(count, allQuotes);

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
            result.AddRange(this.favoriteRepository.ReadQuotes());
            result.AddRange(this.famouseRepository.ReadQuotes());
            result.AddRange(this.othersRepository.ReadQuotes());

            return result;
        }
    }
}
