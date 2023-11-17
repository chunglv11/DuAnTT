using BanDochoi.Web.Data;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;
using BanDochoi.Web.Repositories.IRepository;

namespace BanDochoi.Web.Repositories.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(BanDoChoiDbContext context) : base(context)
        {
        }
    }
}
