using Microsoft.AspNetCore.Mvc;
using R52_M8_Class_01_Work_01.Models;
using R52_M8_Class_01_Work_01.Repositories.Interfaces;

namespace R52_M8_Class_01_Work_01.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepo repo;
        public CategoriesController(ICategoryRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAsync());
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
           if(ModelState.IsValid)
            {
                await repo.InsertAsync(category);
                await repo.CompleteAsync();
                return RedirectToAction("Index");
            }
           return View(category);
        }
        public async Task<IActionResult> Edit( int id)
        {
            return View(await repo.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await repo.UpdateAsync(category);
                await repo.CompleteAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await repo.GetAsync(id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DoDelete(int  id)
        {
           
                Category c= await repo.GetAsync(id);
                await repo.DeleteAsync(c);
                return RedirectToAction("Index");
           
        }
    }
}
