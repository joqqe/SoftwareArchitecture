using SoftwareArchitecture.Domain.Enums;

namespace SoftwareArchitecture.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool Done { get; set; }
    }
}
