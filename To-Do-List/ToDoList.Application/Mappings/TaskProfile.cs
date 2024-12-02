using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappings
{
    public class TaskProfile : Profile
    {
        public TaskProfile() {
            CreateMap<TaskItem, TaskDTO>();
            CreateMap<TaskDTO, TaskItem>();
        }
    }
}
