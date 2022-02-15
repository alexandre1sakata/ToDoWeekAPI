using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Domain.Interfaces.Services;

namespace ToDoWeek.Service.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository repository)
            : base(repository)
        {
            _categoryRepository = repository;
        }
    }
}
