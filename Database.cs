using System;
using MongoDB.Driver;
using MongoEntity.Interfaces;

namespace MongoEntity {

	public class Database {
		public static MongoDatabase Connect( IDatabaseInfo database_info ) {
			if( database_info == null ) throw new Exception( "You genius! Keep trying to connect to MongoDB using 'Null' MongoSettings" );
			
			var Server = new MongoClient( database_info.MongoClientSettings ).GetServer( );
			Server.Connect();

			return Server.GetDatabase( database_info.DatabaseName );
		}
	}

//	public class Database {
//		readonly DatabaseSettings database_settings;
//		public MongoDatabase CurrentDatabase;
//
//		public Database( DatabaseSettings database_settings ) {
//			if( database_settings == null ) throw new Exception( "You genius! Keep trying to connect to MongoDB using 'Null' MongoSettings" );
//			this.database_settings = database_settings;
//		}
//
//		public MongoDatabase Connect() {
//			var Server = MongoServer.Create( database_settings.ServerSettings );
//			Server.Connect();
//
//			return CurrentDatabase = Server.GetDatabase( database_settings.DatabaseName );
//		}
//	}

}