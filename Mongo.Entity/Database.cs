using System;
using Mongo.Entity.Interfaces;
using MongoDB.Driver;

namespace Mongo.Entity {

	public class Database {
		public static MongoDatabase Connect( IDatabaseSettings database_settings ) {
			if( database_settings == null ) throw new Exception( "You genius! Give me a 'DatabaseSettings' so that I can connect you to MongoDB :P" );
			
			var Server = new MongoClient( database_settings.MongoClientSettings ).GetServer( );
			// Server.Connect();

			return Server.GetDatabase( database_settings.DatabaseName );
		}
	}

}