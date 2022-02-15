using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Service.DTO;

namespace ToDoWeek.Service.Mapper.Interfaces
{
    public interface ICategoryMapper
    {
        List<CategoryDTO> MapperEntityListToDto(IEnumerable<Category> categories);
        CategoryDTO MapperEntityToDto(Category category);
        Category MapperDtoToEntity(CategoryDTO categoryDTO);
    }
}
