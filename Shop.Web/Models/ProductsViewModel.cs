using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shop.Web.Data.Entidades;

namespace Shop.Web.Models
{
    public class ProductsViewModel:Produtos
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
