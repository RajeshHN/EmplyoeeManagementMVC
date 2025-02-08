using EmplyoeeManagementMVC.Data;
using EmplyoeeManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmplyoeeManagementMVC.Controllers
{

    public class EmplyoeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmplyoeeController(ApplicationDbContext db)
        {
                _db=db;
        }
        public IActionResult Index()
        {
            List<Emplyoee> objEmplyoeeList = _db.Emplyoees.ToList();
            return View(objEmplyoeeList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Emplyoee obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Emplyoee? EmplyoeefromDb = _db.Emplyoees.FirstOrDefault(e => e.Id == id);
            if (EmplyoeefromDb == null)
            {
                return NotFound();
            }
            return View(EmplyoeefromDb);
        }
        [HttpPost]
        public IActionResult Edit(Emplyoee obj)
        {

            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Emplyoee? EmplyoeefromDb = _db.Emplyoees.FirstOrDefault(e => e.Id == id);
            if (EmplyoeefromDb == null)
            {
                return NotFound();
            }
            return View(EmplyoeefromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Emplyoee? obj = _db.Emplyoees.FirstOrDefault(e => e.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
