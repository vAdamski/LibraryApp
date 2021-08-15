using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Return true if adding goes fine, false in otherway</returns>
        bool Add(Entity entity);
        /// <summary>
        /// Get entity by him id from database
        /// </summary>
        /// <param name="id">Id entity to get</param>
        /// <returns>Return entity with giving id</returns>
        Entity GetById(int id);
        /// <summary>
        /// Delete entity form database
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>Return true if deleting goes fine, false in otherway</returns>
        bool Delete(Entity entity);
        /// <summary>
        /// Get all entities from table
        /// </summary>
        /// <returns>Return list of entities</returns>
        List<Entity> GetAll();
        /// <summary>
        /// Updating entity in database
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>Return true if updating goes fine, false in otherway</returns>
        bool Update(Entity entity);
        /// <summary>
        /// Save changes maked in database
        /// </summary>
        /// <returns>Return true if saveing goes fine, false in otherway</returns>
        bool SaveChanges();
    }
}