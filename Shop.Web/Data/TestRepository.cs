using Shop.Web.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class TestRepository : IRepository
    {
        public void AppProdutos(Produtos produtos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produtos> GetProdutos()
        {
            var produtos = new List<Produtos>();

            produtos.Add(new Produtos { Id = 1, Name = "One", Price = 10 });
            produtos.Add(new Produtos { Id = 2, Name = "Two", Price = 20 });
            produtos.Add(new Produtos { Id = 3, Name = "Three", Price = 30 });
            produtos.Add(new Produtos { Id = 4, Name = "Four", Price = 40 });
            produtos.Add(new Produtos { Id = 5, Name = "Five", Price = 50 });

            return produtos;

        }

        public Produtos GetProdutos(int id)
        {
            throw new NotImplementedException();
        }

        public bool ProdutosExists(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProdutos(Produtos produtos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateProdutos(Produtos produtos)
        {
            throw new NotImplementedException();
        }
    }
}
