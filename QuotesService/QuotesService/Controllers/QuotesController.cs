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
        private readonly QuotesCosmosRepository repository;

        public QuotesController(QuotesHandler quotesHandler, QuotesCosmosRepository repositories) // will be initialized for each request
        {
            this.qutoesHandler = quotesHandler;
            this.repository = repositories;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Quote quote)
        {
            try
            {
                quote.Id = string.Empty; // ensure there is no id already set
                var result = await repository.CreateItemAsync(quote);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Read(string id)
        {
            try
            {
                var result = await repository.GetItemAsync(id);
                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            try
            {
                var result = await repository.GetItemsAsync();
                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, Quote quote)
        {
            try
            {
                quote.Id = id;
                var result = await repository.UpdateItemAsync(id, quote);
                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await repository.DeleteItemAsync(id);
                return new OkObjectResult(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}