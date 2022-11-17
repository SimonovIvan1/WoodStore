using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Models;

namespace WoodStore.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext db;
        public HomeController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.OrderId = id;
            return View();
        }
        [HttpPost]
        public string Create(Goods goods)
        {
            db.Goods.Add(goods);
            db.SaveChanges();
            return "Спасибо за покупку!";
        }
        public IActionResult Index()
        {
            return View(db.Goods.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Goods goods = await db.Goods.FirstOrDefaultAsync(p => p.Id == id);
                if (goods != null)
                    return View(goods);
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                Goods goods = await db.Goods.FirstOrDefaultAsync(p => p.Id == id);
                if (goods != null)
                    return View(goods);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Goods goods)
        {
            db.Goods.Update(goods);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}