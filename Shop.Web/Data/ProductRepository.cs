using Shop.Web.Data.Entidades;

namespace Shop.Web.Data
{
    public class ProductRepository : GenericRepository<Produtos>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }

    }
}
