using Canchas.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetAllWithCustomerAndField();
        Booking GetWithCustomerAndField(int id);
    }
}
