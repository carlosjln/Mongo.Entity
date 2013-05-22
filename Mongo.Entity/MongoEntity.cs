using System;
using Mongo.Entity.Extensions;
using Mongo.Entity.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Entity {

	public abstract class MongoEntity : IMongoEntity {
		// PROPERTIES
		public Guid Id { get; set; }

		protected MongoDatabase database {get; set;}
		
		protected MongoCollection<BsonDocument> collection {get; set;}
		protected IDatabaseSettings database_settings {get; set;}
		protected string collection_name {get; set;}
		
		// CONSTRUCTORS
		protected MongoEntity() {
			var entity_type = GetType();
			var entity_settings = EntitySettings.Get( entity_type );

			use_settings( entity_settings );
		}

		protected MongoEntity( IDatabaseSettings database_settings, string collection_name ) {
			use_settings( new EntitySettings{ DatabaseSettings = database_settings, CollectionName = collection_name } );
		}
		
		// PUBLIC METHODS
		public virtual WriteConcernResult Save() {
			return collection.Save( this );
		}

		public virtual WriteConcernResult Insert() {
			return collection.Insert( this );
		}

		public virtual WriteConcernResult Update() {
			return update( this, UpdateFlags.None );
		}

		public virtual WriteConcernResult Upsert() {
			return update( this, UpdateFlags.Upsert );
		}

		public virtual WriteConcernResult Remove() {
			var query = new QueryDocument( "_id", Id );

			return collection.Remove( query );
		}

		// PRIVATE METHODS
		private WriteConcernResult update( IMongoEntity entity, UpdateFlags update_flags ) {
			var query = new QueryDocument( "_id", entity.Id );
			var update_document = entity.as_update_document();
			
			return collection.Update( query, update_document, update_flags );
		}

		private void use_settings( IEntitySettings entity_settings ) {
			if( entity_settings == null || entity_settings.DatabaseSettings == null ) {
				throw new Exception( "You genius! Give me some 'DatabaseSettings' and a 'Collection name' so that I can connect you to MongoDB" );
			}
			
			database_settings = entity_settings.DatabaseSettings;
			collection_name = entity_settings.CollectionName;

			var server = new MongoClient( database_settings.MongoClientSettings ).GetServer( );
			
			database = server.GetDatabase( database_settings.DatabaseName );
			collection = database.GetCollection( collection_name );
		}
	}

}