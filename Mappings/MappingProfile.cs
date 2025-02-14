using AutoMapper;
using GF_TodoApp.Models;
using GF_TodoApp.Models.DTOs;

namespace GF_TodoApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem,TodoDto>().ReverseMap();
            CreateMap<TodoItem, TodoResponseDto>();
        }
    }
}
