using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entidades;

namespace Shop.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }

        public DbSet<Country> Countries { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }

}
