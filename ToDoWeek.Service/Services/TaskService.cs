using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Domain.Interfaces.Services;
using ToDoWeek.Service.Mapper.Interfaces;

namespace ToDoWeek.Service.Services
{
    public class TaskService : BaseService<Task>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository repository)
            : base(repository)
        {
            _taskRepository = repository;
        }
    }
}
