using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Produtos> Produtos{get; set;}


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }

}
