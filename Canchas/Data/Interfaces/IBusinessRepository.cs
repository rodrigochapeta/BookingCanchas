using Canchas.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Interfaces
{
    public interface IBusinessRepository : IRepository<Business>
    {
        IEnumerable<Business> GetAllWithFields();
        Business GetWithFields(int id);
    }
}
