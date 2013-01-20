using System;
using MongoDB.Driver;

namespace MongoEntity {

	public abstract class MongoEntity : IMongoEntity{
		public Guid Id { get; set; }

		protected MongoDatabase database;
		protected MongoCollection mongo_collection;

		protected Collection collection;
		protected DatabaseSettings database_settings;
		protected string collection_name {get; set;}

		protected MongoEntity( DatabaseSettings database_settings, string collection_name ) {
			if( database_settings == null ) throw new Exception( "You genius! Keep trying to connect to MongoDB using 'Null' MongoSettings" );
			
			this.database_settings = database_settings;
			this.collection_name = collection_name;

			// TODO: remember to upgrade to MongoClient
			var Server = MongoServer.Create( database_settings.ServerSettings );
			Server.Connect();

			database = Server.GetDatabase( database_settings.DatabaseName );
			mongo_collection = database.GetCollection( collection_name );

			collection = new Collection( database, collection_name );
		}

		public override string ToString() {
			throw new NotImplementedException();
			// return this.to_json();
		}
	}

}