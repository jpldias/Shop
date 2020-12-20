using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data;
using Shop.Web.Data.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class ProdutosController : Controller
    {
        public readonly IProductRepository productRepository;

        public ProdutosController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,ImageUrl,LastPurchase,LastSale,IsAvailable,Stock")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                await this.productRepository.CreateAsync(produtos);
                return RedirectToAction(nameof(Index));
            }
            return View(produtos);
        }

        // GET: Produtos/Edit/5
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
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,ImageUrl,LastPurchase,LastSale,IsAvailable,Stock")] Produtos produtos)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await this.productRepository.UpdateAsync(produtos);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.productRepository.ExistsAsync(produtos.Id))
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
            return View(produtos);
        }

        // GET: Produtos/Delete/5
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
