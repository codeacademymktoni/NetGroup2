using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRecipes.Repositories
{
    public class BaseRepository<T> where T: class
    {
        protected readonly MyRecipesDbContext _context;

        public BaseRepository(MyRecipesDbContext context)
        {
            _context = context;
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int entityId)
        {
            return _context.Set<T>().Find(entityId);
        }

        public virtual void Add(T newEntity)
        {
            _context.Set<T>().Add(newEntity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
