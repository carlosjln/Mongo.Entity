using System;
using DummyEntity.Interfaces;

namespace Mongo.Entity.Interfaces {

	public interface IMongoEntity : IEntity {
		new Guid Id {get; set;}
	}

}