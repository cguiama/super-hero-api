using Heroes.Application.Features.Heroes.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Heroes.Application.Features.Heroes.Queries.ListHeroes
{
    public class ListHeroesQuery : IRequest<List<HeroDto>>
    {
    }
}
