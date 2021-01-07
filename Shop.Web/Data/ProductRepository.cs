using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entidades;
using System.Linq;

namespace Shop.Web.Data
{
    public class ProductRepository : GenericRepository<Produtos>, IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUser()
        {
            return this.context.Produtos.Include(p => p.User);
        }
    }
}
