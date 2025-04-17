using Heroes.Application.Features.Heroes.Dtos;
using Heroes.Application.Features.Heroes.Queries.GetHeroById;
using MediatR;

namespace Heroes.Application.Features.Heroes.Commands.UpdateHero
{
    public class UpdateHeroCommand : IRequest<HeroDto>
    {
        public HeroUpdateDto Hero { get; }

        public UpdateHeroCommand(HeroUpdateDto hero)
        {
            Hero = hero;
        }
    }
}
