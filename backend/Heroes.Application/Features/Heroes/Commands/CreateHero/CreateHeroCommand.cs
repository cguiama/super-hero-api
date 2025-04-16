using Heroes.Application.Features.Heroes.Dtos;
using MediatR;

namespace Heroes.Application.Features.Heroes.Commands.CreateHero
{
    public class CreateHeroCommand : IRequest<HeroDto>
    {
        public HeroCreateDto Hero { get; }

        public CreateHeroCommand(HeroCreateDto hero)
        {
            Hero = hero;
        }
    }
}
