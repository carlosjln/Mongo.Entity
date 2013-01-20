using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoEntity.Extensions;

namespace MongoEntity {

	public class Collection {
		public string CollectionName {get; set;}
		public MongoDatabase Database { get; set; }

		public Collection( MongoDatabase database, string collection_name ) {
			Database = database;
			CollectionName = collection_name;
		}

		public SafeModeResult Insert( IMongoEntity entity ) {
			return Insert<BsonDocument>( entity );
		}

		public SafeModeResult Insert<TDocument>( IMongoEntity entity ) {
			if( entity.Id == Guid.Empty) {
				entity.Id = Guid.NewGuid();
			}

			var collection = Database.GetCollection<TDocument>( CollectionName );
			var document_type = entity.GetType();

			var value = Convert.ChangeType( entity, Nullable.GetUnderlyingType( document_type ) ?? document_type );

			// Returns the safe mode result if "safe mode" is enabled, otherwise insert wont wait to confirm the insertion
			// and will return null as per MongoDB driver's design.
			return collection.Insert( document_type, value );
		}

		public SafeModeResult Update( IMongoEntity entity ) {
			return Update<BsonDocument>( entity );
		}

		public SafeModeResult Update<TDocument>( IMongoEntity entity ) {
			var collection = Database.GetCollection<TDocument>( CollectionName );

			// var update_document = entity.ToBsonDocument().to
			var update_document = entity.as_update_document();
			IMongoQuery query = new QueryDocument( "_id", entity.Id );
			
			return collection.Update( query, update_document );
		}

	}

}