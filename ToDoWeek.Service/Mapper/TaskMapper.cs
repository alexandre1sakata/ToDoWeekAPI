using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Service.DTO;
using ToDoWeek.Service.Mapper.Interfaces;

namespace ToDoWeek.Service.Mapper
{
    public class TaskMapper : ITaskMapper
    {
        public List<TaskDTO> MapperEntityListToDto(IEnumerable<Task> tasks, IEnumerable<Category> categories)
        {
            var tasksDTO = new List<TaskDTO>();

            foreach (var task in tasks)
            {
                var category = categories.First(c => c.Id == task.CategoryId);

                tasksDTO.Add(new TaskDTO()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Category = new CategoryDTO()
                    {
                        Id = category.Id,
                        Name = category.Name
                    }
                });
            }

            return tasksDTO;
        }

        public TaskDTO MapperEntityToDto(Task task, Category category)
        {
            return new TaskDTO()
            {
                Id = task.Id,
                Name = task.Name,
                Category = new CategoryDTO()
                {
                    Id = category.Id,
                    Name = category.Name
                }
            };
        }

        public Task MapperDtoToEntity(TaskDTO taskDTO)
        {
            return new Task()
            {
                Id = taskDTO.Id,
                Name = taskDTO.Name,
                CategoryId = taskDTO.Category.Id
            };
        }
    }
}
