using DummyExtensions;
using MongoEntity.Interfaces;

namespace MongoEntity.Extensions {

	public static class mongodb_entity_extensions {
		public static string to_json( this IMongoEntity obj ) {
			return obj.to_bson_document().to_json();
		}
	}

}