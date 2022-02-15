using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoWeek.Domain.Entities;
using ToDoWeek.Domain.Interfaces.Repositories;
using ToDoWeek.Domain.Interfaces.Services;
using ToDoWeek.Infra.Context;
using Xunit;

namespace ToDoWeeek.UnitTests.Services
{
    public class TaskServiceUnitTests
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskService _taskService;
        private readonly Task _task;

        public TaskServiceUnitTests()
        {
            _taskRepository = Substitute.For<ITaskRepository>();
            _taskService = Substitute.For<ITaskService>();

            _task = new Task { Id = 1, Name = "Anything", CategoryId = 0 };

            //Arg.Any<object>()
        }

        [Fact]
        public void GetAllTasks()
        {
            _taskRepository.Select().Returns(new List<Task> { _task, _task });

            var result = _taskService.GetAll();

            //result.Should().NotBeNullOrEmpty();
            //result.Should().BeOfType(new List<Task>().GetType(), result.GetType().ToString());
        }

        [Fact]
        public void GetTaskById()
        {
            _taskRepository.Select(Arg.Any<int>()).Returns(_task);

            var result = _taskService.GetById(_task.Id);

            //result.Should().NotBeNull();
        }

        [Fact]
        public void CreateTask()
        {
            _taskRepository.Insert(Arg.Any<Task>());

            var result = _taskService.Create(_task);

            //result.Should()
        }

        //TODO
        //Code next unit tests

        //UpdateTask
        //DeleteTask
        //GetAllTasksEmpty
        //GetTaskByIdNotFound
        //CreateTaskWithoutInformation
        //UpdateTaskWrongInformation
        //DeleteTaskNotFound
    }
}
