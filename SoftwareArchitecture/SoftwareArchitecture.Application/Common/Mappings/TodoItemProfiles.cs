using AutoMapper;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;

namespace SoftwareArchitecture.Application.Common.Mappings
{
    public class TodoItemProfiles : Profile
    {
        public TodoItemProfiles()
        {
            CreateMap<TodoItem, GetTodoItemDto>();
        }
    }
}
