using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using QuotesService.Model;

namespace QuotesService.Persistence
{
    public class QuotesCosmosRepository
    {
        private readonly string _endpoint;
        private readonly string _key;
        private readonly string _databaseName;
        private readonly string _containerName;
        private CosmosClient _client;
        private Container _container;

        public QuotesCosmosRepository(
            string endpoint,
            string key,
            string databaseName,
            string containerName)
        {
            _endpoint = endpoint;
            _key = key;
            _databaseName = databaseName;
            _containerName = containerName;
        }

        public async Task InitializeAsync()
        {
            try
            {
                // Create a new instance of the DocumentClient class
                // to connect to your Cosmos DB database
                _client = new CosmosClient(_endpoint, _key);

                // Create a new database if it doesn't exist
                Database database = await _client.CreateDatabaseIfNotExistsAsync(_databaseName);

                // Create a new container if it doesn't exist
                _container = await database.CreateContainerIfNotExistsAsync(_containerName, "/id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
         
        }

        public async Task<Quote> CreateItemAsync(Quote item)
        {
            return (await _container.CreateItemAsync(item)).Resource;
        }

        public async Task<Quote> GetItemAsync(string id)
        {
            return await _container.ReadItemAsync<Quote>(id, new PartitionKey(id));
        }

        public async Task<List<Quote>> GetItemsAsync()
        {
            var result = new List<Quote>();
            var iterator = _container.GetItemLinqQueryable<Quote>().ToFeedIterator();
            while (iterator.HasMoreResults)
            {
               result.AddRange(await iterator.ReadNextAsync());
            }

            return result;
        }

        public async Task<Quote> UpdateItemAsync(string id, Quote item)
        {
            return await _container.ReplaceItemAsync<Quote>(item, id);
        }

        public async Task DeleteItemAsync(string id)
        {
            // Use the DocumentClient to delete an item from your container
            await _container.DeleteItemAsync<Quote>(id, new PartitionKey(id));
        }
    }
}
