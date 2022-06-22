using AutoMapper;
using ParkyDiHon_API.Models;
using ParkyDiHon_API.Models.Dtos;

namespace ParkyDiHon_API.Mapper
{
    public class ParkyMapper : Profile
    {
        public ParkyMapper()
        {
            CreateMap<NationalPark,NationalParkDto>().ReverseMap();
        }
    }
}
