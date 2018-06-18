using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFieldRepository : IRepository<Field>
    {
        IEnumerable<Field> GetAllWithGameAndBusiness();
        Field GetWithGameAndBusiness(int id);

        IEnumerable<Field> GetAllWithGameAndBusinessAndBookings();
        Field GetWithGameAndBusinessAndBookings(int id);

    }
}
