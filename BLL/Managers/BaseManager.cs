using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using AutoMapper;

namespace BLL.Managers
{
	public abstract class BaseManager : IBaseManager
	{
		protected readonly MainContext context;
		public BaseManager(MainContext context)
		{
			this.context = context;
		}

		public async Task<int> SaveAsync()
		{
			return await context.SaveChangesAsync();
		}

		public int Save()
		{
			return context.SaveChanges();
		}

		public virtual TEntity GetById<TEntity>(object id) where TEntity : class
		{
			return context.Set<TEntity>().Find(id);
		}

		public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
		{
			if (context.Entry(entity).State == EntityState.Detached)
			{
				context.Set<TEntity>().Attach(entity);
			}
			context.Set<TEntity>().Remove(entity);
		}

		public virtual async Task<TOut> Add<TEntity, TOut>(TOut entity, Action<TEntity, TOut> id) where TEntity : class
		{
			var dbSet = context.Set<TEntity>();
			var dbModel = Mapper.Map<TEntity>(entity);
			dbSet.Add(dbModel);
			await SaveAsync();
			id(dbModel, entity);
			return entity;

		}

		public virtual async Task Delete<TEntity>(object id) where TEntity : class
		{
			TEntity entityToDelete = await context.Set<TEntity>().FindAsync(id);
			Delete(entityToDelete);
			await SaveAsync();
		}

		public virtual async Task<TOut> Get<TEntity, TOut>(object id) where TEntity : class
		{
			var dbSet = context.Set<TEntity>();
			return Mapper.Map<TOut>(await dbSet.FindAsync(id));
		}

		public virtual async Task Update<TEntity, TOut>(TOut entity, Func<TOut, object> id) where TEntity : class
		{
			var dbSet = context.Set<TEntity>();
			var model = await dbSet.FindAsync(id(entity));
			Mapper.Map(entity, model);
			await SaveAsync();
		}
	}
}
