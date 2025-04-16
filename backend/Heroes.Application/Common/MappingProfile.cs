using AutoMapper;
using Heroes.Application.Features.Heroes.Dtos;
using Heroes.Domain.Entities;
using System.Linq;

namespace Heroes.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hero, HeroDto>()
                .ForMember(dest => dest.SuperPowers, opt =>
                    opt.MapFrom(src => src.HeroSuperPowers.Select(hs => hs.SuperPower.Name)));
        }
    }
}
