using Shop.Web.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;

        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;

            this.random = new Random();

        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Produtos.Any())
            {
                this.AddProdutos("Equipamentos Official SlB");
                this.AddProdutos("Chuteiras Oficiais");
                this.AddProdutos("Águia Pequena");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProdutos(string name)
        {
            this.context.Produtos.Add(new Produtos
            {
                Name = name,
                Price = this.random.Next(200),
                IsAvailable = true,
                Stock = this.random.Next(200)
            }); 
        }
    }
}
