using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Infra.Context;

namespace ToDoWeek.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<TEntity> Select()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Select(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.ChangeTracker.Clear();
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<TEntity>().Remove(Select(id));
            _context.SaveChanges();
        }
    }
}
