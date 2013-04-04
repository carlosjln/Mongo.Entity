using MongoDB.Driver;

namespace MongoEntity.Interfaces {

	public interface IDatabaseInfo {
		string ConnectionString { get; }
		string DatabaseName { get; }
		MongoClientSettings MongoClientSettings { get; }
	}

}