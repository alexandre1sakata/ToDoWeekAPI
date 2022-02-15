using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoWeek.Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
