using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopWebApp.Models
{
    public class SqlPieRepository: IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// ** DB Context is now available via DI container, since it is registered in startup :: ConfigureServices()
        /// </summary>
        /// <param name="appDbContext"></param>
        public SqlPieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                //     Specifies related entities to include in the query results. The navigation property
                //     to be included is specified starting with the type of entity being queried (TEntity).
                // ** include Category entity too
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

    }
}
