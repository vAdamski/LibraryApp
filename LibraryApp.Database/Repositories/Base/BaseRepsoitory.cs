using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        protected AppDbContext _dbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
            {
                list.Add(entity);
            }

            return list;
        }

        public Entity GetById(int id)
        {
            var entity = DbSet.FirstOrDefault(x => x.Id == id);

            if (entity != null)
            {
                return entity;
            }

            return null;
        }

        public bool Add(Entity entity)
        {
            DbSet.Add(entity);

            return SaveChanges();
        }

        public bool Delete(Entity entity)
        {
            var entityToDelete = DbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (entityToDelete != null)
            {
                DbSet.Remove(entityToDelete);

                return SaveChanges();
            }

            return false;
        }

        public bool Update(Entity entity)
        {
            if (entity != null)
            {
                DbSet.Update(entity);

                return SaveChanges();
            }

            return false;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
