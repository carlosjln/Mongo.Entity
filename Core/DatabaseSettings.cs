using MongoDB.Driver;

namespace MongoEntity {

	public class DatabaseSettings {
		public string ConnectionString { get; private set; }
		public string DatabaseName { get; private set; }

		public MongoServerSettings ServerSettings { get; private set; }

		public DatabaseSettings( string connection_string, string database_name ) {
			var mongo_url = MongoUrl.Create( connection_string );
			
			ConnectionString = connection_string;
			DatabaseName = database_name;
			
			ServerSettings = mongo_url.ToServerSettings();
		}

		public DatabaseSettings( string connection_string ) {
			var mongo_url = MongoUrl.Create( connection_string );
			
			ConnectionString = connection_string;
			DatabaseName = mongo_url.DatabaseName;
			
			ServerSettings = mongo_url.ToServerSettings();
		}
		
		public DatabaseSettings( MongoServerSettings server_settings ) {
			ServerSettings = server_settings;
		}
	}

}