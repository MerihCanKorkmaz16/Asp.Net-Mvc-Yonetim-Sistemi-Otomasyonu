using CompanyManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.DataAccess.Abstract.Repository
{
    public interface IEntityFrameworkRepository<T> where T:class,IEntity,new()
    {
        List<T> ListOperation(Expression<Func<T,bool>> filter = null);
        T GetOperation(Expression<Func<T, bool>> filter = null);
        void AddOperation(T entity);
        void UpdateOperation(T entity);
        void DeleteOperation(T entity);
    }
}
