using System;
using System.Collections.Generic;
using Mongo.Entity.Interfaces;

namespace Mongo.Entity {
	public sealed class EntitySettings : IEntitySettings {
		public Type EntityType {get; set;}
		public IDatabaseSettings DatabaseSettings {get; set;}
		public string CollectionName {get; set;}

		static readonly Dictionary<Type, EntitySettings> entity_settings_collection = new Dictionary<Type, EntitySettings>();

//		public static void Register<TEntity>( IDatabaseSettings database_settings ) where TEntity : IMongoEntity {
//			Register( typeof( TEntity ), database_settings, collection_name );
//		}

		public static void Register<TEntity>( IDatabaseSettings database_settings, string collection_name ) where TEntity : IMongoEntity {
			Register( typeof( TEntity ), database_settings, collection_name );
		}

		public static void Register( Type entity_type, IDatabaseSettings database_settings, string collection_name ) {
			var settings = new EntitySettings {
				EntityType = entity_type,
				DatabaseSettings = database_settings,
				CollectionName = collection_name
			};
			
			entity_settings_collection.Add( entity_type, settings );
		}

		public static IEntitySettings Get<TEntity>() where TEntity : IMongoEntity {
			return Get( typeof( TEntity ) );
		}

		public static IEntitySettings Get( Type entity_type ) {
			return entity_settings_collection.ContainsKey( entity_type ) ? entity_settings_collection[entity_type] : null;
		}
	}
}