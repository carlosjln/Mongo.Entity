using System;
using Mongo.Entity.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Mongo.Entity.Extensions;

namespace Mongo.Entity {

	public sealed class Collection {
		public string CollectionName {get; set;}
		public MongoDatabase Database { get; set; }

		public Collection( MongoDatabase database, string collection_name ) {
			Database = database;
			CollectionName = collection_name;
		}


//		public WriteConcernResult Save( IMongoEntity entity ) {
//			var collection = Database.GetCollection( CollectionName );
//			return collection.Save( entity );
//		}
//
//		public WriteConcernResult Insert( IMongoEntity entity ) {
//			return Insert<BsonDocument>( entity );
//		}
//
//		public WriteConcernResult Insert<TDocument>( IMongoEntity entity ) {
////			if( entity.Id == Guid.Empty ) {
////				entity.Id = Guid.NewGuid();
////			}
//
//			var collection = Database.GetCollection<TDocument>( CollectionName );
////			var document_type = entity.GetType();
//
////			var value = Convert.ChangeType( entity, Nullable.GetUnderlyingType( document_type ) ?? document_type );
//
//			// Returns the safe mode result if "safe mode" is enabled, otherwise insert wont wait to confirm the insertion
//			// and will return null as per MongoDB driver's design.
////			return collection.Insert( document_type, value );
//			return collection.Insert( entity );
//		}
//
//		public WriteConcernResult Update( IMongoEntity entity ) {
//			return Update<BsonDocument>( entity, UpdateFlags.None );
//		}
//
//		public WriteConcernResult Upsert( IMongoEntity entity ) {
//			return Update<BsonDocument>( entity, UpdateFlags.Upsert );
//		}
//
//		public WriteConcernResult Update<TDocument>( IMongoEntity entity, UpdateFlags update_flags ) {
//			var collection = Database.GetCollection<TDocument>( CollectionName );
//			
//			var query = new QueryDocument( "_id", entity.Id );
//			var update_document = entity.as_update_document();
//			
//			return collection.Update( query, update_document, update_flags );
//		}
//		
//		public WriteConcernResult Remove( IMongoEntity entity ) {
//			var collection = Database.GetCollection( CollectionName );
//			var query = new QueryDocument( "_id", entity.Id );
//
//			return collection.Remove( query );
//		}
	}

}