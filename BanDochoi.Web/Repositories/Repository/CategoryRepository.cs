using BanDochoi.Web.Data;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;
using BanDochoi.Web.Repositories.IRepository;

namespace BanDochoi.Web.Repositories.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BanDoChoiDbContext context) : base(context)
        {
        }
    }
}
