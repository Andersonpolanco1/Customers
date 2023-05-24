using AutoMapper;
using CustomersAPI.Models.DTOs.CountryDtos;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.CityDtos;

namespace CustomersAPI.MapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityCreateDto, City>();
            CreateMap<City, CityReadDto>();
        }
    }
}
