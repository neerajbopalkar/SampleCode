using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopWebApp.Models
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// ** DB Context is now available via DI container, since it is registered in startup :: ConfigureServices()
        /// </summary>
        /// <param name="appDbContext"></param>
        public SqlCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    }
}
