using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Data.Interfaces;
using WoodStore.Models;

namespace WoodStore.Data.Repository
{
    public class GoodsRepository : IBaseRepository<Goods>
    {
        readonly AppDbContext _db;

        public GoodsRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Create(Goods goods)
        {
            _db.Goods.Add(goods);
        }

        public void Delete(int id)
        {
            Goods goods = _db.Goods.Find(id);
            if (goods != null) _db.Goods.Remove(goods);
        }

        public IEnumerable<Goods> GetAll()
        {
            return _db.Goods.ToList();
        }

        public Goods GetById(int id)
        {
            return _db.Goods.FirstOrDefault(goods => goods.Id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Goods goods)
        {
            _db.Entry(goods).State = EntityState.Modified;
        }

    }
}
