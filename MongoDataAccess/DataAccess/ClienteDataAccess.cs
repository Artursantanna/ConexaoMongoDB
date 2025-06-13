using MongoDataAccess.Models;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess
{
    public class ClienteDataAccess
    {
        private const string ConnectionString = "mongodb+srv://artureafa:xx2121xx@cluster0.0radhbo.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        private const string DatabaseName = "TesteDB";
        private const string ClienteCollection = "Cliente";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<List<ClienteModel>> ObterTodos()
        {
            var usersCollection = ConnectToMongo<ClienteModel>(ClienteCollection);
            var result = await usersCollection.FindAsync(_ => true);
            return result.ToList();
        }

        public Task adicionar(ClienteModel cliente)
        {
            var usersCollection = ConnectToMongo<ClienteModel>(ClienteCollection);
            return usersCollection.InsertOneAsync(cliente);
        }


    }
}
