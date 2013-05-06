using Mongo.Entity.Interfaces;
using MongoDB.Driver;

namespace Mongo.Entity {

	public class DatabaseSettings : IDatabaseSettings {
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public MongoClientSettings MongoClientSettings { get; set; }
		
		/// <summary>
		/// Returns an instance of DatabaseSettings with its property values parsed from the specified ConnectionString
		/// </summary>
		public static DatabaseSettings Parse( string connection_string ) {
			var mongo_url = MongoUrl.Create( connection_string );
			
			var database_settings = new DatabaseSettings {
				ConnectionString = connection_string,
				DatabaseName = mongo_url.DatabaseName,
				MongoClientSettings = MongoClientSettings.FromUrl( mongo_url )
			};

			return database_settings;
		}

		protected void parse_from_connection_string( string connection_string ) {
			var mongo_url = MongoUrl.Create( connection_string );
			
			ConnectionString = connection_string;
			DatabaseName = mongo_url.DatabaseName;
			
			MongoClientSettings = MongoClientSettings.FromUrl( mongo_url );
		}
	}

}