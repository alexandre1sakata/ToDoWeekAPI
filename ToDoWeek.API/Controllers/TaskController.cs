using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Services;
using ToDoWeek.Infra.Context;
using ToDoWeek.Service.DTO;
using ToDoWeek.Service.Mapper.Interfaces;

namespace ToDoWeek.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        private ICategoryService _categoryService;

        private ITaskMapper _taskMapper;
        private ICategoryMapper _categoryMapper;

        public TaskController(ITaskService taskService, ICategoryService categoryService, ITaskMapper taskMapper, ICategoryMapper categoryMapper)
        {
            _taskService = taskService;
            _categoryService = categoryService;
            _taskMapper = taskMapper;
            _categoryMapper = categoryMapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDTO>> Get()
        {
            var tasks = _taskService.GetAll();
            var categories = _categoryService.GetAll();
            var tasksDTO = _taskMapper.MapperEntityListToDto(tasks, categories);

            return Ok(tasksDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _taskService.GetById(id);
            var category = _categoryService.GetById(task.CategoryId);
            var taskDTO = _taskMapper.MapperEntityToDto(task, category);

            return Ok(taskDTO);
        }

        [HttpPost]
        public IActionResult Create(TaskDTO taskDTO)
        {
            var task = _taskMapper.MapperDtoToEntity(taskDTO);
            var taskAdded = _taskService.Create(task);

            return Ok(taskAdded);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskDTO taskDTO)
        {
            var taskById = _taskService.GetById(id);

            if (taskById != null)
            {
                var task = _taskMapper.MapperDtoToEntity(taskDTO);
                var taskUpdated = _taskService.Edit(task);

                return Ok(taskUpdated);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskById = _taskService.GetById(id);

            if (taskById != null)
            {
                _taskService.Remove(id);

                return Ok();
            }

            return BadRequest();
        }
    }
}
