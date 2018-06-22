using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        /// <summary>
        /// Bookings IEnumerable with Customer who booked and Field they are using
        /// </summary>
        /// <returns></returns>
        IEnumerable<Booking> GetAllWithCustomerAndField();

        /// <summary>
        /// Bookings IEnumerable with Customer who booked and Field he is using
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Booking GetWithCustomerAndField(int id);
    }
}
