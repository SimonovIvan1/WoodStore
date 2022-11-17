using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Data;
using WoodStore.Data.Interfaces;
using WoodStore.Models;

namespace WoodStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseRepository _baseRepository;

        public HomeController(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IActionResult Index()
        {
            var data = _baseRepository.GetAll<Goods>();
            return View(data.Result);
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.OrderId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            Goods goods = new Goods();
            var data = await _baseRepository.Create<Goods>(goods);
            await _baseRepository.SaveChangesAsync();
            return View(data.Entity);
        }

        public async Task<IActionResult> Details(int id)
        {
            Goods goods = await _baseRepository.GetById<Goods>(id);
            return View(goods);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _baseRepository.Delete<Goods>(id);
            await _baseRepository.SaveChangesAsync();
            return RedirectToAction("Index");          
        }

        /*
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

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Goods goods = await db.Goods.FirstOrDefaultAsync(p => p.Id == id);
                if (goods != null)
                {
                    db.Goods.Remove(goods);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }*/
    }
}