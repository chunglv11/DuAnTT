using BanDochoi.Web.Data;
using BanDochoi.Web.Repositories.IRepository;

namespace BanDochoi.Web.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPostRepository PostRepository { get; }

        BanDoChoiDbContext BanDoChoiDbContext { get; }

        int SaveChange();

        Task<int> SaveChangeAsync();
    }
}
