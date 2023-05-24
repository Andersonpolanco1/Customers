using AutoMapper;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.CountryDtos;

namespace CustomersAPI.MapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryCreateDto, Country>();
            CreateMap<Country, CountryReadDto>();
        }
    }
}
