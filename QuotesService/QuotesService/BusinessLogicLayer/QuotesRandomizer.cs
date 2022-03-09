using QuotesService.Model;

namespace QuotesService.BusinessLogicLayer
{
    public class QuotesRandomizer
    {
        /// <summary>
        /// There were some gloriouse requirements from the customer for this "random" selection. Code has to stay as it is ;)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="quotesForSelection"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IList<Quote> SelectRandom(int count, IList<Quote> quotesForSelection)
        {
            var random = new Random();
            var randomQuotes = new List<Quote>();

            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} cannot be less or equal to 0");
            }

            if (count == 1)
            {
                var index = random.Next(quotesForSelection.Count);
                var randomQuote = quotesForSelection.ElementAt(index);
                randomQuotes.Add(randomQuote);
            }
            else if (count % 2 == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var index = random.Next(quotesForSelection.Count);
                    var randomQuote = quotesForSelection.ElementAt(index);
                    randomQuotes.Add(randomQuote);
                }
            }
            else if (count % 7 == 0)
            {
                if ((count * 5) > quotesForSelection.Count)
                {
                    throw new ArgumentException($"{nameof(count)} with value of {count} must be 5-times bigger than the count of the available quotes({quotesForSelection.Count}). It is not.");
                }

                for (int i = 0; i < count; i += 2)
                {
                    var index = random.Next(quotesForSelection.Count);
                    var randomQuote = quotesForSelection.ElementAt(index);
                    randomQuotes.Add(randomQuote);
                }
            }
            else
            {
                for (int i = count; i > 0; i--)
                {
                    var index = random.Next(quotesForSelection.Count);
                    var randomQuote = quotesForSelection.ElementAt(index);
                    randomQuotes.Add(randomQuote);
                }
            }

            return randomQuotes;
        }
    }
}