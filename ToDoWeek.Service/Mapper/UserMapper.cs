using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Service.DTO;
using ToDoWeek.Service.Mapper.Interfaces;

namespace ToDoWeek.Service.Mapper
{
    public class UserMapper : IUserMapper
    {
        public List<UserDTO> MapperEntityListToDto(IEnumerable<User> users)
        {
            var usersDTO = new List<UserDTO>();

            foreach (var user in users)
            {
                usersDTO.Add(new UserDTO() 
                { 
                    Id = user.Id, 
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password
                });
            }

            return usersDTO;
        }

        public UserDTO MapperEntityToDto(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }

        public User MapperDtoToEntity(UserDTO userDTO)
        {
            return new User()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
            };
        }
    }
}
