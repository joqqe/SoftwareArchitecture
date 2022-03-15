using System.ComponentModel.DataAnnotations;

namespace SoftwareArchitecture.Application.Common.Validations
{
    public static class TodoValidator
    {
        public static void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ValidationException("Title should not be null, empty or consist only of white-space characters");

            if (title.Length > 200)
                throw new ValidationException("Title should not exceed a character count of 200");
        }
    }
}
