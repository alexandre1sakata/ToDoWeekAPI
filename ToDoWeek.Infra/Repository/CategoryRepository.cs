using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Infra.Context;

namespace ToDoWeek.Infra.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext context)
            : base(context)
        {
            _appDbContext = context;
        }
    }
}
