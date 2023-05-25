using AutoMapper;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.CustomerDtos;

namespace CustomersAPI.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<Customer, CustomerReadDto>()
                .ForMember(src => src.Gender, dest => dest.MapFrom(src => src.Gender == Gender.Male ? "Male" : "Female" ));
        }
    }
}
