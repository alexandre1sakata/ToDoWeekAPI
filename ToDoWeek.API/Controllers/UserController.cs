using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces;
using ToDoWeek.Domain.Interfaces.Services;
using ToDoWeek.Infra.Context;
using ToDoWeek.Service.DTO;
using ToDoWeek.Service.Mapper.Interfaces;

namespace ToDoWeek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IUserMapper _userMapper;

        public UserController(IUserService service, IUserMapper mapper)
        {
            _userService = service;
            _userMapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            var users = _userService.GetAll();
            var usersDTO = _userMapper.MapperEntityListToDto(users);

            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            var userDTO = _userMapper.MapperEntityToDto(user);

            return Ok(userDTO);
        }

        [HttpPost]
        public IActionResult Create(UserDTO userDTO)
        {
            var user = _userMapper.MapperDtoToEntity(userDTO);
            var userAdded = _userService.Create(user);

            return Ok(userAdded);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDTO userDTO)
        {
            var taskById = _userService.GetById(id);

            if (taskById != null)
            {
                var task = _userMapper.MapperDtoToEntity(userDTO);
                var taskUpdated = _userService.Edit(task);

                return Ok(taskUpdated);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskById = _userService.GetById(id);

            if (taskById != null)
            {
                _userService.Remove(id);

                return Ok();
            }

            return BadRequest();
        }
    }
}
