using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Infra.Context;

namespace ToDoWeek.Infra.Repository
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskRepository(AppDbContext context)
            : base(context)
        {
            _appDbContext = context;
        }
    }
}
