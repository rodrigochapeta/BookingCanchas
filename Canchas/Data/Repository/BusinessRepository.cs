using Canchas.Data.Interfaces;
using Canchas.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Repository
{
    public class BusinessRepository : Repository<Business> , IBusinessRepository
    {
        public BusinessRepository(CanchasDbContext context) : base(context)
        {

        }

        public IEnumerable<Business> GetAllWithFields()
        {
            return _context.Businesses 
                    .Include(a => a.Fields);
        }

        public Business GetWithFields(int id)
        {
            return _context.Businesses
                .Where(a=> a.Id == id)
                .Include(a => a.Fields)
                .FirstOrDefault();
        }
    }
}
