﻿namespace CarMgmt.Core
{
	public interface IRepository<T> where T : BaseEntity
	{
		IEnumerable<T> GetAll();

		Task<T> GetById(int id);

		Task<T> GetByStatus(Status status);

		Task Add(T entity);

		void Update(T entity);

		Task Delete(int id);
	}
}
