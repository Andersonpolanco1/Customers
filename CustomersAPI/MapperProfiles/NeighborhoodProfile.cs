using AutoMapper;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.NeighborhoodDtos;

namespace CustomersAPI.MapperProfiles
{
    public class NeighborhoodProfile : Profile
    {
        public NeighborhoodProfile()
        {
            CreateMap<NeighborhoodCreateDto, Neighborhood>();
            CreateMap<Neighborhood, NeighborhoodReadDto>();
        }
    }
}