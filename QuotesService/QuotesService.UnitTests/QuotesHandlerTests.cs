using NUnit.Framework;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using System.Linq;

namespace QuotesService.UnitTests
{
    public class QuotesHandlerTests
    {

        [Test]
        public void Get_QuotesAvailable_ShouldReturnMiaWallaceQuote()
        {
            // arrange
            var handler = new QuotesHandler();

            // act
            var allQuotes = handler.Get(System.Guid.Empty);
            var miaWallaceQuote = allQuotes.SingleOrDefault(q => q.Author == "Mia Wallace");

            // assert
            Assert.That(miaWallaceQuote, Is.Not.Null);
            Assert.That(miaWallaceQuote?.Content, Is.EqualTo("That's when you know you found somebody really special. When you just shut the fuck up for a minute and comfortably share silence."));
        }

        [Test]
        public void AddOrUpdate_NewQuote_ShouldAddNewQuote()
        {
            // arrange
            var handler = new QuotesHandler();
            var newQuote = new Quote
            {
                Content = "Aw, man. I shot Marvin in the face.",
                Author = "Vincent Vega",
                AdditionalInformation = "Pulp Fiction",
                Type = QuoteType.FAMOUSE,
            };

            // act
            var quoteResult = handler.AddOrUpdate(newQuote);

            // assert
            Assert.That(quoteResult, Is.Not.Null);
            Assert.That(quoteResult?.Id, Is.Not.Empty);
        }

        [Test]
        public void Delete_QuoteAvailable_ShouldDeleteQuote()
        {
            // arrange
            var handler = new QuotesHandler();

            // act && assert
            Assert.DoesNotThrow(() => handler.DeleteQuote(System.Guid.Parse("c54acf19-b6f6-4abb-8acf-e2927835d3da")));
        }
    }
}