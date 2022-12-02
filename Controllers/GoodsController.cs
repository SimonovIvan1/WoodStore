using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Data;
using WoodStore.Models;

namespace WoodStore.Controllers
{
    public class GoodsController : Controller
    {
        readonly AppDbContext db;
        public GoodsController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("GetGoods");
            ViewBag.GoodsId = id;
            return View();
        }
        [HttpPost]
        public string Create(Goods goods)
        {
            db.Goods.Add(goods);
            db.SaveChanges();
            return "Добавлен новый товар.";
        }
        public IActionResult GetGoods()
        {
            /*var goods = db.Goods.Join(db.Provider, // второй набор
            u => u.ProviderId, // свойство-селектор объекта из первого набора
            c => c.Id, // свойство-селектор объекта из второго набора
            (u, c) => new // результат
                {
                    Name = u.Name,
                    Company = c.Name,
                    Age = u.Material
                });*/
            
            return View(db.Goods.ToList().Distinct());
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
            return RedirectToAction("GetGoods");
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
                    return RedirectToAction("GetGoods");
                }
            }
            return NotFound();
        }
    }
}