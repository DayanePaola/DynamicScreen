using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(int id);
        int SaveChanges();
    }
}
