using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IBaseManager
	{
		Task<TOut> Add<TEntity, TOut>(TOut entity, Action<TEntity, TOut> id) where TEntity : class;
		Task Update<TEntity, TOut>(TOut entity, Func<TOut, object> id) where TEntity : class;
		Task<TOut> Get<TEntity, TOut>(object id) where TEntity : class;
		Task Delete<TEntity>(object id) where TEntity : class;
	
	}
}
