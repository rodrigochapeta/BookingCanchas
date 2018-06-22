using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBusinessRepository : IRepository<Business>
    {
        /// <summary>
        /// Bring business IEnumerable with all fields
        /// </summary>
        /// <returns></returns>
        IEnumerable<Business> GetAllWithFields();

        /// <summary>
        /// Brings Business with its fields
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Business GetWithFields(int id);


    }
}
