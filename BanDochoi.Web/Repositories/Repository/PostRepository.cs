using BanDochoi.Web.Data;
using BanDochoi.Web.Infrastructures;
using BanDochoi.Web.Models;
using BanDochoi.Web.Repositories.IRepository;

namespace BanDochoi.Web.Repositories.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(BanDoChoiDbContext context) : base(context)
        {
        }
    }
}
