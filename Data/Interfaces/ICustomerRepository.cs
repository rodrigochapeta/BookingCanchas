using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICustomerRepository :  IRepository<Customer>
    {
        /// <summary>
        /// Brings IEnumerable with their bookings
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetAllWithBookings();

        /// <summary>
        /// Brings one customer with all his bookings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer GetWithBookings(int id);
    }
}
