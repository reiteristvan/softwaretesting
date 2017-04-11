using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogIn.DataAccess
{
    public class GenericRepository<TEntity>
        where TEntity : EntityBase
    {
        // Probably not a good idea with huge datasets :)
        public virtual IEnumerable<TEntity> All()
        {
            using (BlogInDbContext context = new BlogInDbContext())
            {
                return context.Set<TEntity>().ToList();
            }
        } 

        public virtual TEntity FindById(Guid id)
        {
            using (BlogInDbContext context = new BlogInDbContext())
            {
                return context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            }
        }

        public virtual void Create(TEntity entity)
        {
            using (BlogInDbContext context = new BlogInDbContext())
            {
                context.Set<TEntity>().Attach(entity);
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (BlogInDbContext context = new BlogInDbContext())
            {
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (BlogInDbContext context = new BlogInDbContext())
            {
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}