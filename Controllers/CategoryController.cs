using Microsoft.AspNetCore.Mvc;
using VakifbankIntern.Data;
using VakifbankIntern.Models;

namespace VakifbankIntern.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) { 
            _db = db;
        }
       
        public IActionResult Index()
        {
            List<Category> objCategoryList= _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj, string? Name)
        {
            
            
            
            if (obj.DisplayOrder.ToString() == "")
            {
                ModelState.AddModelError("name","bu alan bos bırakılamaz");
            }
           if( ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges(); 
             return RedirectToAction("Index");
            }
             return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(Id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //[HttpPatch]
        //public IActionResult Edit(Category obj)
        //{
           
        //}
    }
}
