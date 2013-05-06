using System;

namespace Mongo.Entity.Interfaces {
	public interface IEntitySettings {
		Type EntityType { get; set; }
		IDatabaseSettings DatabaseSettings { get; set; }
		string CollectionName { get; set; }
	}
}