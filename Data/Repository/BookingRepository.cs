using Data.Interfaces;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(CanchasDbContext context) : base(context)
        {

        }
        public IEnumerable<Booking> GetAllWithCustomerAndField()
        {
            return _context.Bookings
                .Include(a => a.Customer)
                .Include(a => a.Field);
        }
        public Booking GetWithCustomerAndField(int id)
        {
            return _context.Bookings
                .Where(a => a.Id == id)
                .Include(a => a.Customer)
                .Include(a => a.Field)
                .FirstOrDefault();
        }

    }
}
