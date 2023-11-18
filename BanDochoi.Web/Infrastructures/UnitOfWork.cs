using BanDochoi.Web.Data;
using BanDochoi.Web.Repositories.IRepository;
using BanDochoi.Web.Repositories.Repository;

namespace BanDochoi.Web.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BanDoChoiDbContext context;
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        private IPostRepository postRepository;
        public UnitOfWork(BanDoChoiDbContext context)
        {
            this.context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(this.context);
                }
                return this.categoryRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(this.context);
                }
                return this.productRepository;
            }
        }
        public IPostRepository PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(this.context);
                }
                return this.postRepository;
            }
        }
        public BanDoChoiDbContext BanDoChoiDbContext => this.context;

        public void Dispose()
        {
            this.context.Dispose();
        }

        public int SaveChange()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
