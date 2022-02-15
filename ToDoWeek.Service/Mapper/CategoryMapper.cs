using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Service.DTO;
using ToDoWeek.Service.Mapper.Interfaces;

namespace ToDoWeek.Service.Mapper
{
    public class CategoryMapper : ICategoryMapper
    {
        public List<CategoryDTO> MapperEntityListToDto(IEnumerable<Category> categories)
        {
            var categoriesDTO = new List<CategoryDTO>();

            foreach (var category in categories)
            {
                categoriesDTO.Add(new CategoryDTO()
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return categoriesDTO;
        }

        public Category MapperDtoToEntity(CategoryDTO categoryDTO)
        {
            return new Category()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name
            };
        }

        public CategoryDTO MapperEntityToDto(Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
