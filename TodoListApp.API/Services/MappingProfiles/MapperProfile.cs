using AutoMapper;
using TodoListApp.Entities.DbSet;
using TodoListApp.Entities.Dtos;

namespace TodoListApp.API.Services.MappingProfiles;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<CreateTaskRequest, Todo>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        
        CreateMap<Todo, CreateTaskRequest>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        
        CreateMap<UpdateTaskRequest, Todo>();
        CreateMap<Todo, UpdateTaskRequest>();
        
         }
}