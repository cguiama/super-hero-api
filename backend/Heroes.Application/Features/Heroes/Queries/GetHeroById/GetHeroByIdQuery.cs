using Heroes.Application.Features.Heroes.Dtos;
using MediatR;

namespace Heroes.Application.Features.Heroes.Queries.GetHeroById
{
    public record GetHeroByIdQuery(Guid Id) : IRequest<HeroDto>;
}
