using MongoDB.Driver;

namespace Mongo.Entity.Interfaces {

	public interface IDatabaseSettings {
		string ConnectionString { get; }
		string DatabaseName { get; }
		MongoClientSettings MongoClientSettings { get; }
	}

}