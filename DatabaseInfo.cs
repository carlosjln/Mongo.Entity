using MongoDB.Driver;
using MongoEntity.Interfaces;

namespace MongoEntity {
	// TODO: consider changing the set method(s) to protected

	public abstract class DatabaseInfo : IDatabaseInfo {
		public string ConnectionString { get; protected set; }
		public string DatabaseName { get; protected set; }
		public MongoClientSettings MongoClientSettings { get; protected set; }

		public void Set( string connection_string, string database_name ) {
			var mongo_url = MongoUrl.Create( connection_string );
			
			ConnectionString = connection_string;
			DatabaseName = database_name;
			
			MongoClientSettings = MongoClientSettings.FromUrl( mongo_url );
		}

		public void Set( string connection_string ) {
			var mongo_url = MongoUrl.Create( connection_string );
			
			ConnectionString = connection_string;
			DatabaseName = mongo_url.DatabaseName;
			
			MongoClientSettings = MongoClientSettings.FromUrl( mongo_url );
		}
		
		public void Set( MongoClientSettings mongo_client_settings ) {
			MongoClientSettings = mongo_client_settings;
		}
	}

}