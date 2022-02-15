using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Infra.Context;

namespace ToDoWeek.Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext context)
            : base(context)
        {
            _appDbContext = context;
        }
    }
}
