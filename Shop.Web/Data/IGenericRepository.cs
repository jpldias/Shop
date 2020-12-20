using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entidades);

        Task UpdateAsync(T entidades);

        Task DeleteAsync(T entidades);

        Task<bool> ExistsAsync(int id);


    }
}
