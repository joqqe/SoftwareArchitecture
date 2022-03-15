using NUnit.Framework;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Domain.Enums;

namespace SoftwareArchitecture.Domain.UnitTests.Entities
{
    public class TodoItemTests
    {
        [Test]
        public void EqualsShouldReturnTrue()
        {
            var expect = new TodoItem
            {
                Id = 1,
                Title = "Title",
                Priority = PriorityLevel.Medium,
                Done = false
            };

            var actual = new TodoItem
            {
                Id = 1,
                Title = "Title",
                Priority = PriorityLevel.Medium,
                Done = false
            };

            Assert.IsTrue(expect.Equals(actual));
        }

        [Test]
        public void EqualsShouldReturnFalse()
        {
            var expect = new TodoItem
            {
                Id = 1,
                Title = "Title 1",
                Priority = PriorityLevel.Medium,
                Done = false
            };

            var actual = new TodoItem
            {
                Id = 1,
                Title = "Title 2",
                Priority = PriorityLevel.Medium,
                Done = false
            };

            Assert.IsFalse(expect.Equals(actual));
        }

        [Test]
        public void EqualsNullShouldReturnFalse()
        {
            var expect = new TodoItem
            {
                Id = 1,
                Title = "",
                Priority = PriorityLevel.Medium,
                Done = false
            };

            TodoItem actual = null;

            Assert.IsFalse(expect.Equals(actual));
        }
    }
}
