using System;
using DummyEntity.Interfaces;

namespace MongoEntity.Interfaces {

	public interface IMongoEntity : IEntity {
		new Guid Id {get; set;}
	}

}