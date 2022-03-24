using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Infra.Context;
using Xunit;

namespace ToDoWeeek.UnitTests.Repositories
{
    public class TaskRepositoryUnitTests
    {
        private readonly DbContextOptions<AppDbContext> options;

        public TaskRepositoryUnitTests()
        {
            string dbName = Guid.NewGuid().ToString();
            options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
        }

        [Fact]
        public void Adding_new_task()
        {
            using (AppDbContext appDbContext = new AppDbContext(options))
            {
                Task task = new Task() { Id = 1, Name = "Study Programming", CategoryId = 1 };

                appDbContext.Tasks.Add(task);
                appDbContext.SaveChanges();

                Task taskAdded = appDbContext.Tasks.Find(1);

                taskAdded.Should().NotBe(null);
                taskAdded.Id.Should().Be(1);
                taskAdded.Name.Should().Be("Study Programming");
                taskAdded.CategoryId.Should().Be(1);
            }
        }
    }
}
