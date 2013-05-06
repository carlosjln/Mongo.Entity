using System;
using Mongo.Entity.Interfaces;
using MongoDB.Driver;

namespace Mongo.Entity {
	// TODO: consider changing the set method(s) to protected

//	[Obsolete("Instead use DatabaseSettings",true)]
//	public abstract class DatabaseInfo : IDatabaseInfo {
//		public string ConnectionString { get; protected set; }
//		public string DatabaseName { get; protected set; }
//		public MongoClientSettings MongoClientSettings { get; protected set; }
//
//		public void Set( string connection_string, string database_name ) {
//			var mongo_url = MongoUrl.Create( connection_string );
//			
//			ConnectionString = connection_string;
//			DatabaseName = database_name;
//			
//			MongoClientSettings = MongoClientSettings.FromUrl( mongo_url );
//		}
//
//		public void Set( string connection_string ) {
//			var mongo_url = MongoUrl.Create( connection_string );
//			
//			ConnectionString = connection_string;
//			DatabaseName = mongo_url.DatabaseName;
//			
//			MongoClientSettings = MongoClientSettings.FromUrl( mongo_url );
//		}
//		
//		public void Set( MongoClientSettings mongo_client_settings ) {
//			MongoClientSettings = mongo_client_settings;
//		}
//	}


	public class DatabaseSettings : IDatabaseSettings {
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public MongoClientSettings MongoClientSettings { get; set; }

//		public void Set( string connection_string, string database_name ) {
//			var mongo_url = MongoUrl.Create( connection_string );
//			
//			ConnectionString = connection_string;
//			DatabaseName = database_name;
//			
//			MongoClientSettings = MongoClientSettings.FromUrl( mongo_url );
//		}

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