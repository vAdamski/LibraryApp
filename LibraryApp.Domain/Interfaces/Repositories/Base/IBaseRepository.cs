using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        bool Add(Entity entity);
        Entity GetById(int id);
        bool Delete(Entity entity);
        List<Entity> GetAll();
        bool Update(Entity entity);
        bool SaveChanges();
    }
}