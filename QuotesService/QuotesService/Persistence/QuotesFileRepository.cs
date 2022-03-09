using QuotesService.Model;
using System.Text.Json;

namespace QuotesService.Persistence
{
    public class QuotesFileRepository
    {
        private static object lockObject = new object();
        private readonly string path;
        private readonly QuoteType type;

        public QuotesFileRepository(string path, QuoteType type)
        {
            this.path = path;
            this.type = type;
        }
       
        public IList<Quote> ReadQuotes()
        {
            lock (lockObject)
            {
                string result = string.Empty;
                var resultList = new List<Quote>();

                try
                {
                    result = File.ReadAllText(path);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (!string.IsNullOrEmpty(result))
                {
                    resultList.AddRange(JsonSerializer.Deserialize<List<Quote>>(result));
                }

                return resultList;
            }
        }

        public void WriteQuotes(IList<Quote> quotes)
        {
            this.EnsureFileExists();

            lock (lockObject)
            {
                var quotesToUpdate = quotes.Where(q => q.Type == this.type);
                var result = JsonSerializer.Serialize(quotesToUpdate);
                File.WriteAllText(path, result);
            }
        }

        private void EnsureFileExists()
        {
            lock (lockObject) // used because of async environment
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
            }
        }
    }
}