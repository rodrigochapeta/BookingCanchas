using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{ 
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Grab all without filters
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        
        /// <summary>
        /// Find with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Func<T, bool> predicate);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Create new entity in database
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Update entity already existing in database
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete from database // HardDELETE
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Count with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Func<T, bool> predicate);


    }
}
 
