using Shop.Web.Data.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;

        //ligação a base de dados 
        public Repository(DataContext context)
        {
            this.context = context;
        }


        // retornar todos os produtos da tabela 
        public IEnumerable<Produtos> GetProdutos()
        {
            return this.context.Produtos.OrderBy(p => p.Name);
        }



        //retornar um produto expecifico da tabela 
        public Produtos GetProdutos(int id)
        {
            return this.context.Produtos.Find(id);
        }


        // adicionar um produto na tabela 
        public void AppProdutos(Produtos produtos)
        {
            this.context.Produtos.Add(produtos);
        }



        //editar ou atualizar um produto na tabela 
        public void UpdateProdutos(Produtos produtos)
        {
            this.context.Produtos.Update(produtos);
        }



        //remover um produto
        public void RemoveProdutos(Produtos produtos)

        {
            this.context.Produtos.Remove(produtos);
        }



        // gravar na tabela 
        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }



        // verificar se produto existe ou nao na tabela 
        public bool ProdutosExists(int id)
        {
            return this.context.Produtos.Any(p => p.Id == id);
        }

    }
}
