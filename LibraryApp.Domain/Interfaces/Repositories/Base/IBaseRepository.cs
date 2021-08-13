using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        bool Add(Entity entity);
        bool Delete(Entity entity);
        List<Entity> GetAll();
        bool SaveChanges();
    }
}