using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Domain.Interfaces.Services;
using ToDoWeek.Service.Mapper.Interfaces;

namespace ToDoWeek.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
            :base (repository)
        {
            _userRepository = repository;
        }
    }
}
