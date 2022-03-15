using NUnit.Framework;
using SoftwareArchitecture.Application.Common.Validations;
using System.ComponentModel.DataAnnotations;

namespace SoftwareArchitecture.Application.UnitTests.Common.Validator
{
    public class TodoValidationExceptionTests
    {
        [Test]
        public void Title_ValidString_ThrowsNoValidationException()
        {
            var title = "valid string";

            try
            {
                TodoItemValidator.Title(title);
                Assert.Pass();
            }
            catch (ValidationException)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Title_EmptyString_ThrowsValidationException()
        {
            var title = string.Empty;

            try
            {
                TodoItemValidator.Title(title);
                Assert.Fail();
            }
            catch (ValidationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Title_Null_ThrowsValidationException()
        {
            string title = null;

            try
            {
                TodoItemValidator.Title(title);
                Assert.Fail();
            }
            catch (ValidationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Title_WhiteSpaces_ThrowsValidationException()
        {
            string title = " ";

            try
            {
                TodoItemValidator.Title(title);
                Assert.Fail();
            }
            catch (ValidationException)
            {
                Assert.Pass();
            }
        }
    }
}
