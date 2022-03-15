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
                TodoValidator.ValidateTitle(title);
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
                TodoValidator.ValidateTitle(title);
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
                TodoValidator.ValidateTitle(title);
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
                TodoValidator.ValidateTitle(title);
                Assert.Fail();
            }
            catch (ValidationException)
            {
                Assert.Pass();
            }
        }
    }
}
