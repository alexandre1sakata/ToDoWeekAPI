using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Domain.Interfaces.Services;

namespace ToDoWeek.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IList<TEntity> GetAll()
        {
            return _repository.Select();
        }

        public TEntity GetById(int id)
        {
            return _repository.Select(id);
        }

        public TEntity Create(TEntity entity)
        {
            _repository.Insert(entity);
            return entity;
        }

        public TEntity Edit(TEntity entity)
        {
            _repository.Update(entity);
            return entity;
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }
    }
}
