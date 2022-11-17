using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Data.Interfaces;
using WoodStore.Models.Interfaces;

namespace WoodStore.Data.Repository
{
    public class Repository : IBaseRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync() //where T : class, IEntity
        {
            await _context.SaveChangesAsync();
        }

        public async Task<EntityEntry<T>> Create<T>(T Model) where T : class, IEntity
        {
           return await _context.Set<T>().AddAsync(Model);
        }

        public async Task<bool> Delete<T>(int id) where T : class, IEntity
        {
            if(id > 0)
            {
                var model = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                if(model != null)
                {
                    _context.Set<T>().Remove(model);
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById<T>(int id) where T : class, IEntity
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EntityEntry<T>> Update<T>(T Model, int id) where T : class, IEntity
        {
            if (id > 0)
            {
                var model = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                if (model != null)
                {
                    model.Id = id;
                    return _context.Set<T>().Update(Model);
                }
            }
            return null;
        }

        public Task Update<T>(T goods)
        {
            throw new NotImplementedException();
        }
    }
}
