using System;

namespace Mongo.Entity.Interfaces {
	public interface IMongoEntity {
		Guid Id { get; }
	}
}