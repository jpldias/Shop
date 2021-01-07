using Shop.Web.Data.Entidades;
using System.Linq;

namespace Shop.Web.Data
{
    public interface IProductRepository : IGenericRepository<Produtos>
    {
        IQueryable GetAllWithUser();
    }
}
