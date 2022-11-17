using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Models.Interfaces;

namespace WoodStore.Data.Interfaces
{
    public interface IBaseRepository
    {
        Task SaveChangesAsync();

        Task<EntityEntry<T>> Create<T>(T Model) where T : class, IEntity;

        Task<EntityEntry<T>> Update<T>(T Model, int id) where T: class, IEntity;

        Task<bool> Delete<T>(int id) where T : class, IEntity;

        Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity;

        Task<T> GetById<T>(int id) where T : class, IEntity;
        Task Update<T>(T goods);
    }
}
