using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> GetAllWithFields();
        Game GetWithFields(int id);
    }
}
