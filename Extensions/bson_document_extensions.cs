using System.Collections.Generic;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoEntity.Extensions {

	public static class bson_document_extensions {
		public static UpdateDocument as_update_document( this IMongoEntity entity ) {
			return as_update_document(entity, true);
		}

		public static UpdateDocument as_update_document( this IMongoEntity entity, bool exclude_null_values ) {
			var bson_document = entity.ToBsonDocument();
			bson_document.Remove( "_id" );
			bson_document.Remove( "_t" );

			if( exclude_null_values ) {
				var to_remove = new List<BsonElement>( );

				foreach( var item in bson_document.Elements ) {
					if( item.Value.IsBsonNull ) to_remove.Add( item );
				}

				foreach( var item in to_remove ) {
					bson_document.RemoveElement( item );
				}
			}

		 	return new UpdateDocument( "$set", bson_document );
		}
	}

}