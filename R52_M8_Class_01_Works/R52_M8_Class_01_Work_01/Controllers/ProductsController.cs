using Microsoft.AspNetCore.Mvc;
using R52_M8_Class_01_Work_01.Models;
using R52_M8_Class_01_Work_01.Repositories.Interfaces;
using R52_M8_Class_01_Work_01.ViewModels;

namespace R52_M8_Class_01_Work_01.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo repo;
        public ProductsController(IProductRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetWithIncludeAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await repo.GetCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductInputModel product)
        {
            if (ModelState.IsValid)
            {
                await repo.InsertAsysnc(new Product
                {
                    CategoryId = product.CategoryId,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice
                });
                await repo.CompleteAsysnc();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await repo.GetCategoriesAsync();
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await repo.GetCategoriesAsync();
            var product = await repo.GetAsync(id);
            return View(new ProductInputModel 
            { 
                Id=product.Id,
                ProductName=product.ProductName,
                UnitPrice=product.UnitPrice,
                CategoryId=product.CategoryId
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductInputModel product)
        {
            if (ModelState.IsValid)
            {
                var existing = await repo.GetAsync(product.Id);
                existing.ProductName= product.ProductName;
                existing.UnitPrice= product.UnitPrice;
                existing.CategoryId= product.CategoryId;
                await repo.UpdateAsysnc(existing);
                await repo.CompleteAsysnc();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await repo.GetCategoriesAsync();
            return View(product);
        }
    }

}