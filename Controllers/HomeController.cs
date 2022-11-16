using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    }
}