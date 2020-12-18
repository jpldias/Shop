﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Data.Entidades
{
    public class Produtos
    {
        public int Id { get; set; }


        [MaxLength(50,ErrorMessage = "Limite de 50 Caracteres")]
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Ultima Compra")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Ultima Venda")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Disponivel")]
        public bool IsAvailable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
    }
}