using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodStore.Data.Interfaces
{
    public interface IBaseRepository<T> 
    {
        IEnumerable<T> GetAll(); 
        T GetById(int id); 
        public void Create(T entity); 
        public void Update(T entity); 
        public void Delete(int id); 
        public void Save(); 
    }
}
