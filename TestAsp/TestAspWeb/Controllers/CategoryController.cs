using Microsoft.AspNetCore.Mvc;
using TestAspWeb.Data;
using TestAspWeb.Models;

namespace TestAspWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Создание
        //GET
        public IActionResult Create()
        {
          
            return View();
        }
        //Создание
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category ct)
        {
            if (ct.Name == ct.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customererror", "Ты дурачаек?");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(ct);
                _db.SaveChanges();
                TempData["success"] = "Категория успешно создана";
                return RedirectToAction("Index");
            }
            return View(ct);
        }
        //Изменение
        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);

            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //Изменение
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category ct)
        {
            if (ct.Name == ct.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customererror", "Ты дурачаек?");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(ct);
                _db.SaveChanges();
                TempData["success"] = "Категория успешно изменена";
                return RedirectToAction("Index");
            }
            return View(ct);
        }

        //Удаление
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //Удаление
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category ct)
        {
          
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(ct);
                _db.SaveChanges();
                TempData["success"] = "Категория успешно удалена";
                return RedirectToAction("Index");
            }
            return View(ct);
        }
    }
}

