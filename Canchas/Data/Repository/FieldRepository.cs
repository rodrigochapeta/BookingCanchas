using Canchas.Data.Interfaces;
using Canchas.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Repository
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        public FieldRepository(CanchasDbContext context) : base(context)
        {
        }

        public IEnumerable<Field> GetAllWithGameAndBusiness()
        {
            return _context.Fields
                .Include(a => a.Business)
                .Include(a => a.Game);
        }

        public IEnumerable<Field> GetAllWithGameAndBusinessAndBookings()
        {
            return _context.Fields
               .Include(a => a.Business)
               .Include(a => a.Bookings)
               .Include(a => a.Game);
        }

        public Field GetWithGameAndBusiness(int id)
        {
            return _context.Fields
                   .Where(a => a.Id == id)
                   .Include(a => a.Business) 
                   .Include(a => a.Game)
                   .FirstOrDefault();
        }

        public Field GetWithGameAndBusinessAndBookings(int id)
        {
            return _context.Fields
                .Where(a=> a.Id == id)
               .Include(a => a.Business)
               .Include(a => a.Bookings)
               .Include(a => a.Game)
               .FirstOrDefault();
        }
    }
}
