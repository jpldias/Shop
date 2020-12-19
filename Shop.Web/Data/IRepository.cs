using Shop.Web.Data.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public interface IRepository
    {
        void AppProdutos(Produtos produtos);

        IEnumerable<Produtos> GetProdutos();

        Produtos GetProdutos(int id);

        bool ProdutosExists(int id);

        void RemoveProdutos(Produtos produtos);

        Task<bool> SaveAllAsync();

        void UpdateProdutos(Produtos produtos);

    }
}