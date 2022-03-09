using NUnit.Framework;
using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using System;
using System.Collections.Generic;

namespace QuotesService.UnitTests
{
    /// <summary>
    /// Class for Exercise 2 
    /// </summary>
    [TestFixture]
    public class QuotesRandomizerTests
    {
        [Test]
        public void SelectRandom_CountIs1_ShouldReturn1Quote()
        {
            // arrange
            var randomizer = new QuotesRandomizer();
            var quotes = GetQuotes();

            // act
            var result = randomizer.SelectRandom(1, quotes);

            // arrange
            Assert.That(result.Count, Is.EqualTo(1));
        }

        // ToDo: Add as many tests as you think is needed to test the class "QuotesRandomizer"

        [Test]
        public void SelectRandom_CountIs3_ShouldReturn3Quotes()
        {
            Assert.Pass();           
        }

        [Test]
        public void SelectRandom_CountIs14_ShouldReturn_HowManyQuotes_Quotes()
        {
            Assert.Pass();
        }

        [Test]
        public void SelectRandom_CountIs0_ShouldThrow_What()
        {
            Assert.Pass();
        }

        private IList<Quote> GetQuotes()
        {
            return new List<Quote>
            {
                new Quote
                {
                    AdditionalInformation = "TV Show",
                    Author = "Tom Cruise",
                    Content = "I love lip sinc!",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Song",
                    Author = "Danger Dan",
                    Content = "Das ist alles der Kunstfreiheit gedeckt.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Work",
                    Author = "PVO",
                    Content = "Huerä dammi siech nomau!",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Food",
                    Author = "Any Kepab Seller",
                    Content = "Mit oder ohni?",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Spare Time",
                    Author = "MMU",
                    Content = "Muesch di haut eifach häbä.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Romantic Movie",
                    Author = "Any person breaking up",
                    Content = "It is not you, it's me.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Movie",
                    Author = "Jules Winnfield",
                    Content = "Does he look like a bitch?",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Real Life",
                    Author = "Unknown",
                    Content = "Lieber nie als zu spät.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "TV Show",
                    Author = "Butters",
                    Content = "No, I'm lying.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                new Quote
                {
                    AdditionalInformation = "Life",
                    Author = "Theodore Roosevelt",
                    Content = "It is hard to fail but it is worse never to have tried to succeed.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
                 new Quote
                {
                    AdditionalInformation = "Life",
                    Author = "Thomas A. Edison",
                    Content = "I have not failed. I’ve just found 10,000 ways that won’t work.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Art",
                    Author = "Michelangelo",
                    Content = "The greater damage for most of us is not that our aim is too high and we miss it, but that it it too low and we reach it.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Science",
                    Author = "Albert Einstein",
                    Content = "You can’t blame gravity for falling in love.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Movie",
                    Author = "Dorothy Gale",
                    Content = "Toto, I've got a feeling we're not in Kansas anymore.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Movie",
                    Author = "Han Solo",
                    Content = "May the Force be with you.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Movie",
                    Author = "Forrest Gump",
                    Content = "Mama always said life was like a box of chocolates. You never know what you're gonna get.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Movie",
                    Author = "Michelle",
                    Content = "Oh, and this one time, at band camp...",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Movie",
                    Author = "James Bond",
                    Content = "Bond. James Bond.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                }, new Quote
                {
                    AdditionalInformation = "Real Life",
                    Author = "KNA",
                    Content = "Das ist doch einfach dämlich.",
                    Id = Guid.NewGuid(),
                    Type = QuoteType.SOMEONE_OTHERS_FAVORITE,
                },
            };
        }
    }
}
