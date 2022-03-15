using System.ComponentModel.DataAnnotations;

namespace SoftwareArchitecture.Application.Common.Validations
{
    public static class TodoItemValidator
    {
        /// <summary>
        /// Checks if value is a valid Title
        /// </summary>
        /// <exception cref="ValidationException">Throws when title is null, empty, consist of only white-space or exceed 200 chars</exception>
        /// <param name="title"></param>
        public static void Title(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ValidationException("Title should not be null, empty or consist of only white-space chars");

            if (title.Length > 200)
                throw new ValidationException("Title should not exceed a character count of 200");
        }
    }
}
