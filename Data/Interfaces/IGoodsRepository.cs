using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Models;
using WoodStore.Models.Interfaces;

namespace WoodStore.Data.Interfaces
{
    public interface IGoodsRepository
    {
        Task<EntityEntry<Goods>> Create(Goods Model);

        Task<EntityEntry<Goods>> Update(Goods Model, int id);

        Task<bool> Delete<Goods>(int id);

        Task<IEnumerable<Goods>> GetAll();

        Task<Goods> GetById(int id);
    }
}
