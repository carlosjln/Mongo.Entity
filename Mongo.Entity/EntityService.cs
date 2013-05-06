using Mongo.Entity.Interfaces;
using MongoDB.Driver;

namespace Mongo.Entity {

	public sealed class EntityService {
		/// <summary>
		/// Gets a MongoServer instance based on the settings set for the provided TEntity.
		/// </summary>
		public static MongoServer GetServer<TEntity>() where TEntity : IMongoEntity {
			var entity_settings = EntitySettings.Get<TEntity>();

			return new MongoClient( entity_settings.DatabaseSettings.MongoClientSettings ).GetServer();
		}

		/// <summary>
		/// Gets a MongoDatabase instance connected to the database specified on the settings set for the provided TEntity.
		/// </summary>
		public static MongoDatabase GetDatabase<TEntity>() where TEntity : IMongoEntity {
			var entity_settings = EntitySettings.Get<TEntity>();
			var database_settings = entity_settings.DatabaseSettings;
			var server = new MongoClient( database_settings.MongoClientSettings ).GetServer();

			return server.GetDatabase( database_settings.DatabaseName );
		}

		/// <summary>
		/// Gets a MongoCollection instance connected to the database and collection specified on the settings set for the provided TEntity.
		/// </summary>
		public static MongoCollection<TEntity> GetCollection<TEntity>() where TEntity : IMongoEntity {
			var entity_settings = EntitySettings.Get<TEntity>();
			var database_settings = entity_settings.DatabaseSettings;

			var server = new MongoClient( database_settings.MongoClientSettings ).GetServer();
			var database = server.GetDatabase( database_settings.DatabaseName );

			return database.GetCollection<TEntity>( entity_settings.CollectionName );
		}
	}

}