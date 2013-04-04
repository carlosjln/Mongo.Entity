using System;
using MongoDB.Driver;
using MongoEntity.Interfaces;

namespace MongoEntity {

	public abstract class MongoEntity : IMongoEntity{
		public Guid Id { get; set; }

		protected MongoDatabase database;
		protected MongoCollection mongo_collection;

		protected Collection collection;
		protected IDatabaseInfo DatabaseInfo;
		protected string collection_name {get; set;}

		protected MongoEntity( IDatabaseInfo DatabaseInfo, string collection_name ) {
			if( DatabaseInfo == null ) throw new Exception( "You genius! Keep trying to connect to MongoDB using 'Null' MongoSettings" );
			
			this.DatabaseInfo = DatabaseInfo;
			this.collection_name = collection_name;

			// TODO: remember to upgrade to MongoClient
			var Server = new MongoClient( DatabaseInfo.MongoClientSettings ).GetServer( );
			Server.Connect();

			database = Server.GetDatabase( DatabaseInfo.DatabaseName );
			mongo_collection = database.GetCollection( collection_name );

			collection = new Collection( database, collection_name );
		}

		public override string ToString() {
			throw new NotImplementedException();
			// return this.to_json();
		}
	}

}