using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;

namespace ToDoWeek.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> 
            where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity obj);
        TEntity Edit(TEntity obj);
        void Remove(int id);
    }
}
