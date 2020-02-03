using NUnit.Framework;
using RemindersDemo.Models;
using RemindersDemo.Mappers;
using System;

namespace Tests
{
    public class MappingTests
    {
        [Test]
        public void Map_InputIsEmpty_TaskIsOverDue()
        {
            //arrange
            var taskItem = new TaskItemWithUsers();
            var userId = Guid.NewGuid();
            //act
            var subject = ModelMapper.Map(taskItem, userId);
            //assert
            Assert.AreEqual(true, subject.OverDue);
        }

        [Test]
        public void Map_InputHasFutureDueDate_TaskIsNotOverDue()
        {
            //arrange
            var taskItem = new TaskItemWithUsers() { DateDue = DateTime.Today.AddDays(1)};
            var userId = Guid.NewGuid();
            //act
            var subject = ModelMapper.Map(taskItem, userId);
            //assert
            Assert.AreEqual(false, subject.OverDue);
        }

        [Test]
        public void Map_InputEscalationUserIsYou_TaskIsEscalatedByYou()
        {
            //arrange
            var userId = Guid.NewGuid();
            var taskItem = new TaskItemWithUsers() { EscalationUser = userId};
            //act
            var subject = ModelMapper.Map(taskItem, userId);
            //assert
            Assert.True(subject.EscalatedByYou);
        }

        [Test]
        public void Map_InputEscalationUserIsNotYou_TaskIsNotEscalatedByYou()
        {
            //arrange
            var userId = Guid.NewGuid();
            var taskItem = new TaskItemWithUsers() { EscalationUser = userId };
            //act
            var subject = ModelMapper.Map(taskItem, Guid.NewGuid());
            //assert
            Assert.False(subject.EscalatedByYou);
        }

        [Test]
        public void Map_InputPopulated_ResultFullyPopulated()
        {
            //arrange
            var escalationUserId = Guid.NewGuid(); 
            var taskItem = new TaskItemWithUsers()
            {
                EscalationUser = escalationUserId,
                AssignedUser = Guid.NewGuid(),
                DateCreated = DateTime.Today,
                DateDue = DateTime.Today.AddDays(1),
                Description = "test description",
                Id = Guid.NewGuid(),
                AssignedUserName = "bob",
                EscalationUserName = "alice",
                OpenStatus = true
            };
            //act
            var subject = ModelMapper.Map(taskItem, escalationUserId);
            //assert computed fields
            Assert.True(subject.EscalatedByYou);
            Assert.False(subject.OverDue);
            //assert mapped fields
            Assert.AreEqual(taskItem.AssignedUser, subject.AssignedUser);
            Assert.AreEqual(taskItem.EscalationUser, subject.EscalationUser);
            Assert.AreEqual(taskItem.Id, subject.Id);
            Assert.AreEqual(taskItem.Description, subject.Description);
            Assert.AreEqual(taskItem.DateDue, subject.DateDue);
            Assert.AreEqual(taskItem.DateCreated, subject.DateCreated);
            Assert.AreEqual(taskItem.AssignedUserName, subject.AssignedUserName);
            Assert.AreEqual(taskItem.EscalationUserName, subject.EscalationUserName);
            Assert.AreEqual(taskItem.OpenStatus, subject.OpenStatus);
        }

    }
}