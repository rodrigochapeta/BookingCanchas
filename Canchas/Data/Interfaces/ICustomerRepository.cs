using Canchas.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Interfaces
{
    public interface ICustomerRepository :  IRepository<Customer>
    {
        IEnumerable<Customer> GetAllWithBookings();
        Customer GetWithBookings(int id);
    }
}
