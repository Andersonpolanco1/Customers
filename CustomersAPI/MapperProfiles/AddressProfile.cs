using AutoMapper;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.AddressDto;

namespace CustomersAPI.MapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressCreateDto, Address>();
        }
    }
}
