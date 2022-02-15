using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoWeek.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}
