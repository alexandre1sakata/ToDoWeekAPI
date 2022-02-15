using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Service.DTO;

namespace ToDoWeek.Service.Mapper.Interfaces
{
    public interface ITaskMapper
    {
        List<TaskDTO> MapperEntityListToDto(IEnumerable<Task> tasks, IEnumerable<Category> categories);
        TaskDTO MapperEntityToDto(Task task, Category category);
        Task MapperDtoToEntity(TaskDTO taskDTO);
    }
}
