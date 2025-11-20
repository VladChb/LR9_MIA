using MongoDB.Driver;
namespace BookHubAPI.Models;
public class MongoDBClient
{
	private static IMongoDatabase _db;
	private static MongoDBClient _instance;

    public static MongoDBClient Instance
	{
		get => _instance ?? new MongoDBClient();
	}

    private MongoDBClient()
	{
        var connectionString = "mongodb+srv://ChabaniukVladuslav:123456789Vladuslav@cluster0.mrfdr7l.mongodb.net/?appName=Cluster0"; // або URI від MongoDB Atlas
        var client = new MongoClient(connectionString);
        _db = client.GetDatabase("BookHubDB");

    }

	public IMongoCollection<T> GetCollection<T>(string name) => _db.GetCollection<T>(name);
}