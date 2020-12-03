using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Data.Respository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly Context Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(Context db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            SaveChanges();
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
