using System;
using DummyEntity.Interfaces;

namespace MongoEntity {

	public interface IMongoEntity : IEntity {
		new Guid Id {get; set;}
	}

}