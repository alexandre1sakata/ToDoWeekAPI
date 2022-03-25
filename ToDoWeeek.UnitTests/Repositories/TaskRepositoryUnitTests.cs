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
        private readonly AppDbContext appDbContext;

        public TaskRepositoryUnitTests()
        {
            string dbName = Guid.NewGuid().ToString();
            options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            appDbContext = new AppDbContext(options);

            var tasks = new List<Task>
            {
                new Task(){ Id = 1, Name = "Study Programming", CategoryId = 1 },
                new Task(){ Id = 2, Name = "Practice Exercise", CategoryId = 2 },
                new Task(){ Id = 3, Name = "Watch Film", CategoryId = 3 }
            };

            tasks.ForEach(tk =>
            {
                appDbContext.Tasks.Add(tk);
            });

            appDbContext.SaveChanges();
        }

        [Fact]
        public void Getting_all_tasks()
        {
            var allTasks = appDbContext.Tasks.ToListAsync();

            allTasks.Result.Should().NotBeNull();
            allTasks.Result.Count.Should().BeGreaterThan(1);
        }

        [Fact]
        public void Getting_task_by_id()
        {
            Task task = appDbContext.Tasks.Find(2);

            task.Should().NotBeNull();
            task.Id.Should().Be(2);
            task.Name.Should().Be("Practice Exercise");
            task.CategoryId.Should().Be(2);
        }

        [Fact]
        public void Adding_new_task()
        {
            Task newTask = new Task() { Id = 4, Name = "Study English", CategoryId = 1 };

            appDbContext.Tasks.Add(newTask);
            appDbContext.SaveChanges();

            Task taskAdded = appDbContext.Tasks.Find(4);

            taskAdded.Should().NotBeNull();
            taskAdded.Id.Should().Be(4);
            taskAdded.Name.Should().Be("Study English");
            taskAdded.CategoryId.Should().Be(1);
        }

        [Fact]
        public void Updating_task_by_id()
        {
            Task newTask = new Task() { Id = 5, Name = "Play games", CategoryId = 3 };

            appDbContext.Tasks.Add(newTask);
            appDbContext.SaveChanges();

            Task taskToUpdate = appDbContext.Tasks.Find(5);
            taskToUpdate.Name = "Watch Series";

            appDbContext.Tasks.Update(taskToUpdate);
            appDbContext.SaveChanges();

            Task taskUpdated = appDbContext.Tasks.Find(5);

            taskUpdated.Should().NotBeNull();
            taskUpdated.Id.Should().Be(5);
            taskUpdated.Name.Should().Be("Watch Series");
            taskUpdated.CategoryId.Should().Be(3);
        }

        [Fact]
        public void Deleting_task_by_id()
        {
            Task newTaskToDelete = new Task() { Id = 6, Name = "Read Book", CategoryId = 1 };

            appDbContext.Tasks.Add(newTaskToDelete);
            appDbContext.SaveChanges();

            appDbContext.Tasks.Remove(appDbContext.Tasks.Find(6));
            appDbContext.SaveChanges();

            Task taskDeleted = appDbContext.Tasks.Find(6);

            taskDeleted.Should().BeNull();
        }
    }
}
