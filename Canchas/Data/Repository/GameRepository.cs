using Canchas.Data.Interfaces;
using Canchas.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(CanchasDbContext context) : base(context)
        {
        }

        public IEnumerable<Game> GetAllWithFields()
        {
            return _context.Games 
                .Include(a => a.Fields);
        }

        public Game GetWithFields(int id)
        {
            return _context.Games
                .Where(a => a.Id == id)
                .Include(a => a.Fields)
                .FirstOrDefault();
        }
    }
}
