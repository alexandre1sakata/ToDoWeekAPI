using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Service.DTO;

namespace ToDoWeek.Service.Mapper.Interfaces
{
    public interface IUserMapper
    {
        List<UserDTO> MapperEntityListToDto(IEnumerable<User> users);
        UserDTO MapperEntityToDto(User user);
        User MapperDtoToEntity(UserDTO userDTO);
    }
}
