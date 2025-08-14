using AutoMapper;
using NET8API.Models.DTO;

namespace NET8API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           CreateMap<NET8API.Models.Domain.Task, TaskDto>().ReverseMap();                
        }
    }
}
