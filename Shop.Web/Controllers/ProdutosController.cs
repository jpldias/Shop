using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data;
using Shop.Web.Data.Entidades;
using Shop.Web.Helpers;
using Shop.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{


    //só entra nos produtos se tiver logado com o authorize por baixo e nostros campos obriga a fazer login que é o caso so creat edit e delete
    //[Authorize]  tirei este para se poder ver os produtos mas em baixo é obrigado a logar
    public class ProdutosController : Controller
    {
        public readonly IProductRepository productRepository;
        private readonly IUserHelper userHelper;

        public ProdutosController(IProductRepository productRepository, IUserHelper userHelper)
        {
            this.productRepository = productRepository;
            this.userHelper = userHelper;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            return View(this.productRepository.GetAll()/*.OrderBy(p =>p.Name)*/);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await this.productRepository.GetByIdAsync(id.Value);

            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // GET: Produtos/Create



        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,ImageFile,LastPurchase,LastSale,IsAvailable,Stock")] ProductsViewModel view)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if(view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";



                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Products",
                        file);

                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Products/{file}";

                }

                var produtos = this.ToProducts(view, path);

               
                produtos.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);


                await this.productRepository.CreateAsync(produtos);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Produtos ToProducts(ProductsViewModel view, string path)
        {
            return new Produtos
            {
                Id = view.Id,
                ImageUrl = path,
                IsAvailable = view.IsAvailable,
                LastPurchase = view.LastPurchase,
                LastSale = view.LastSale,
                Name = view.Name,
                Price = view.Price,
                Stock = view.Stock,
                User = view.User
            };
        }

        // GET: Produtos/Edit/5

        [Authorize]
        public async Task<IActionResult>  Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await this.productRepository.GetByIdAsync(id.Value);
            if (produtos == null)
            {
                return NotFound();
            }

            var view = this.ToProductsViewModel(produtos);



            return View(view);
        }

        private ProductsViewModel ToProductsViewModel(Produtos produtos)
        {
            return new ProductsViewModel
            {
                Id = produtos.Id,
                ImageUrl = produtos.ImageUrl,
                IsAvailable = produtos.IsAvailable,
                LastPurchase = produtos.LastPurchase,
                LastSale = produtos.LastSale,
                Name = produtos.Name,
                Price = produtos.Price,
                Stock = produtos.Stock,
                User = produtos.User
            };
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,ImageFile,LastPurchase,LastSale,IsAvailable,Stock")] ProductsViewModel view)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        path = string.Empty;

                        if (view.ImageFile != null && view.ImageFile.Length > 0)
                        {
                            var guid = Guid.NewGuid().ToString();
                            var file = $"{guid}.jpg";



                            path = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot\\images\\Products",
                                file);

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await view.ImageFile.CopyToAsync(stream);
                            }

                            path = $"~/images/Products/{file}";

                        }

                        var produtos = this.ToProducts(view, path);

                        
                        produtos.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                        await this.productRepository.UpdateAsync(produtos);

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.productRepository.ExistsAsync(view.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Produtos/Delete/5

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await this.productRepository.GetByIdAsync(id.Value);
            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtos = await this.productRepository.GetByIdAsync(id);
            await this.productRepository.DeleteAsync(produtos);
            return RedirectToAction(nameof(Index));
        }


    }
}
