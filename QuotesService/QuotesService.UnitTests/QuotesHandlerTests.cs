using NUnit.Framework;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using System;
using System.Collections.Generic;
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
            };

            // act
            var queriedQuotes = handler.Get(miasId, allQuotes);
            var miaWallaceQuote = queriedQuotes.SingleOrDefault();

            // assert
            Assert.That(miaWallaceQuote, Is.Not.Null);
            Assert.That(miaWallaceQuote?.Content, Is.EqualTo("That's when you know you found somebody really special. When you just shut the fuck up for a minute and comfortably share silence."));
        }

        [Test]
        public void AddOrUpdate_NewQuote_ShouldAddNewQuote()
        {
            // arrange
            var handler = new QuotesHandler();
            var allQuotes = new List<Quote>();
            var newQuote = new Quote
            {
                Content = "Aw, man. I shot Marvin in the face.",
                Author = "Vincent Vega",
                AdditionalInformation = "Pulp Fiction",
                Type = QuoteType.FAMOUSE,
            };

            // act
            var quoteResult = handler.AddOrUpdate(newQuote, allQuotes);

            // assert
            Assert.That(quoteResult, Is.Not.Null);
            Assert.That(quoteResult?.Id, Is.Not.Empty);
        }

        [Test]
        public void Delete_QuoteAvailable_ShouldDeleteQuote()
        {
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
            };

            // act && assert
            Assert.DoesNotThrow(() => handler.DeleteQuote(miasId, allQuotes));
        }
    }
}