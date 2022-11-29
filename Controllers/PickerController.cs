using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Data;
using WoodStore.Models;
using WoodStore.Models.Entity;

namespace WoodStore.Controllers
{
    public class PickerController : Controller
    {
        readonly AppDbContext db;
        public PickerController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("GetPickers");
            ViewBag.PickerId = id;
            return View();
        }
        [HttpPost]
        public string Create(Picker picker)
        {
            db.Picker.Add(picker);
            db.SaveChanges();
            return "Добро пожаловать в компанию! :)";
        }
        public IActionResult GetPickers()
        {
            return View(db.Picker.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Picker picker = await db.Picker.FirstOrDefaultAsync(p => p.Id == id);
                if (picker != null)
                    return View(picker);
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                Picker picker = await db.Picker.FirstOrDefaultAsync(p => p.Id == id);
                if (picker != null)
                    return View(picker);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Picker picker)
        {
            db.Picker.Update(picker);
            await db.SaveChangesAsync();
            return RedirectToAction("GetPickers");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Picker picker = await db.Picker.FirstOrDefaultAsync(p => p.Id == id);
                if (picker != null)
                    return View(picker);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Picker picker = await db.Picker.FirstOrDefaultAsync(p => p.Id == id);
                if (picker != null)
                {
                    db.Picker.Remove(picker);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetPickers");
                }
            }
            return NotFound();
        }
    }
}