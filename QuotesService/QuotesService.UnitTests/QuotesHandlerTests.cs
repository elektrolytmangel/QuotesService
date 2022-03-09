using NUnit.Framework;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotesService.UnitTests
{
    /// <summary>
    /// Class for Exercise 1 
    /// </summary>
    [TestFixture]
    public class QuotesHandlerTests
    {
        [Test]
        public void Get_QuotesAvailable_ShouldReturnMiaWallaceQuote()
        {
            // ToDo: add test to check if quote can be added
            // arrange
            // Already done:
            // 1. instantiate QuotesHandler
            // 2. prepare list of Quote with one quote and give an id which you know: https://guidgenerator.com/

            // arrange
            var handler = new QuotesHandler();
            Guid miasId = Guid.Parse("87f80773-f9f9-47d4-8210-bc84c8ae247f");
            var allQuotes = new List<Quote>
            {
                new Quote
                {
                    Id = miasId,
                    Author = "Mia Wallace",
                    Content = "That's when you know you found somebody really special. When you just shut the fuck up for a minute and comfortably share silence.",
                    AdditionalInformation = "Pulp Fiction",
                },
                new Quote
                {
                    Id = Guid.NewGuid(),
                    Author = "Marvin",
                    Content = "Man, I don't even have an opinion. ",
                    AdditionalInformation = "Pulp Fiction",
                },
            };

            // act
            // ToDo: 
            // 1. Execute the action: QuotesHandler.Get with the known id
            // 2. select the single result and assign it to an variable i.e. miaWallaceQuote
            IList<Quote> selectedQuotes = handler.Get(miasId, allQuotes);

            // assert
            // ToDo:
            // 1. Assert that the result of the action is not null
            // 2. Assert that the result of the action has a content which is equal to "That's when you know you found somebody really special. When you just shut the fuck up for a minute and comfortably share silence."
            Assert.That(selectedQuotes.SingleOrDefault(), Is.Not.Null);
            Assert.That(selectedQuotes.SingleOrDefault()?.Content, Is.EqualTo("That's when you know you found somebody really special. When you just shut the fuck up for a minute and comfortably share silence."));

            // ToDo: Execute the test
        }

        [Test]
        public void AddOrUpdate_NewQuote_ShouldAddNewQuote()
        {
            // ToDo: add test to check if quote can be added
            // arrange
            // ToDo:
            // 1. instantiate QuotesHandler
            // 2. prepare empty list of Quote

            // act
            // ToDo: 
            // 1. Execute the action: QuotesHandler.AddOrUpdate

            // assert
            // ToDo:
            // 1. Assert that the result of the action is not null
            // 2. Assert that the result of the action has an id which is not empty

            // ToDo: Execute the test
        }

        [Test]
        public void Delete_QuoteAvailable_ShouldDeleteQuote()
        {
            // ToDo: add test to check if quote can be deleted
            // arrange
            // ToDo:
            // 1. instantiate QuotesHandler
            // 2. prepare list of Quote with one quote and give an id which you know: https://guidgenerator.com/

            // act && assert
            // ToDo: 
            // 1. Execute the action: QuotesHandler.DeleteQuote
            // 2. Wrap it into your expected Assert: Assert.DoesNotThrow(() => YourDelete-Action);

            // ToDo: Execute the test
        }

        [Test]
        public void AddOrUpdate_UpdateQuote_ShouldUpdateQuote()
        {
            // ToDo: add test to check if quote can be added
            // arrange
            // ToDo:
            // 1. instantiate QuotesHandler
            // 2. prepare list of Quote with one quote and give an id which you know: https://guidgenerator.com/
            // 3. perpare a Quote which has some changed properties

            // act
            // ToDo: 
            // 1. Execute the action: QuotesHandler.AddOrUpdate

            // assert
            // ToDo:
            // 1. Assert that the result of the action is not null
            // 2. Assert that the result of the action has an id which is not empty
            // 3. Assert that the result of the action has its properties changed
            // 4. Assert that the result is also updated in the list of Quotes

            // ToDo: Execute the test
        }
    }
}