using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoWeek.Service.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
