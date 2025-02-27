using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PAW.Data.Models;
using PAW.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PAW.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
