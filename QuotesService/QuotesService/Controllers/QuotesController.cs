using Microsoft.AspNetCore.Mvc;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;

namespace QuotesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(Quote quote)
        {
            try
            {
                quote.Id = Guid.Empty;
                var handler = new QuotesHandler();
                var result = handler.AddOrUpdate(quote);
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
                var handler = new QuotesHandler();
                var result = handler.Get(id);
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
                var handler = new QuotesHandler();
                var result = handler.Get(Guid.Empty);
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
                var handler = new QuotesHandler();
                quote.Id = id;
                var result = handler.AddOrUpdate(quote);
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
                var handler = new QuotesHandler();
                var result = handler.DeleteQuote(id);
                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}