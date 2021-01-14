using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entidades;
using Shop.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context,IUserHelper  userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();

        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();


            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");



            var user = await this.userHelper.GetUserByEmailAsync("jpldias13@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Joao",
                    LastName = "Dias",
                    Email = "jpldias13@gmail.com",
                    UserName = "jpldias13@gmail.com",
                    PhoneNumber = "523456789"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Nao conseguiu criar o utilizador na seed");
                }


                await this.userHelper.AddUserToRoleAsync(user, "Admin");

            }
            var isRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");

            if (!isRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }


            if (!this.context.Produtos.Any())
            {
                this.AddProdutos("Equipamentos Official SlB", user);
                this.AddProdutos("Chuteiras Oficiais", user);
                this.AddProdutos("Águia Pequena", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProdutos(string name, User user)
        {
            this.context.Produtos.Add(new Produtos
            {
                Name = name,
                Price = this.random.Next(200),
                IsAvailable = true,
                Stock = this.random.Next(200),
                User = user
            });
        }
    }
}
