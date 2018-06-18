using Data.Interfaces;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CanchasDbContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetAllWithBookings()
        {
            return _context.Customers
                .Include(a => a.Bookings);
        }

        public Customer GetWithBookings(int id)
        {
            return _context.Customers
                .Where(a=> a.Id == id)
                .Include(a => a.Bookings)
                .FirstOrDefault();
        }
    }
}
