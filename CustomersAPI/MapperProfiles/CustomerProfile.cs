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
            CreateMap<Customer, CustomerReadDto>();
        }
    }
}
