using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;

namespace ToDoWeek.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
            where TEntity : BaseEntity
    {
        IList<TEntity> Select();
        TEntity Select(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
