using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Data;
using WoodStore.Models;
using WoodStore.Models.Entity;

namespace WoodStore.Controllers
{
    public class GoodsInOrderController : Controller
    {
        readonly AppDbContext db;
        public GoodsInOrderController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("GetAll");
            ViewBag.GoodsInOrderId = id;
            return View();
        }
        [HttpPost]
        public string Create(GoodsInOrder goodsInOrder)
        {
            db.GoodsInOrder.Add(goodsInOrder);
            db.SaveChanges();
            return "Товар добавлен в заказ";
        }
        public IActionResult GetAll()
        {
            return View(db.GoodsInOrder.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                GoodsInOrder goodsInOrder = await db.GoodsInOrder.FirstOrDefaultAsync(p => p.Id == id);
                if (goodsInOrder != null)
                    return View(goodsInOrder);
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                GoodsInOrder goodsInOrder = await db.GoodsInOrder.FirstOrDefaultAsync(p => p.Id == id);
                if (goodsInOrder != null)
                    return View(goodsInOrder);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(GoodsInOrder goodsInOrder)
        {
            db.GoodsInOrder.Update(goodsInOrder);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                GoodsInOrder goodsInOrder = await db.GoodsInOrder.FirstOrDefaultAsync(p => p.Id == id);
                if (goodsInOrder != null)
                    return View(goodsInOrder);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                GoodsInOrder goodsInOrder = await db.GoodsInOrder.FirstOrDefaultAsync(p => p.Id == id);
                if (goodsInOrder != null)
                {
                    db.GoodsInOrder.Remove(goodsInOrder);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetAll");
                }
            }
            return NotFound();
        }
    }
}