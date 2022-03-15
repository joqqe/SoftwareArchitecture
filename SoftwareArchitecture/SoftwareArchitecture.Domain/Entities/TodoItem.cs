using SoftwareArchitecture.Domain.Enums;

namespace SoftwareArchitecture.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool Done { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
                return false;

            return this.Id == ((TodoItem)obj).Id
                && this.Title == ((TodoItem)obj).Title
                && this.Priority == ((TodoItem)obj).Priority
                && this.Done == ((TodoItem)obj).Done;
        }
    }
}
