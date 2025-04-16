using AutoMapper;
using Heroes.Application.Features.Heroes.Dtos;
using Heroes.Application.Interfaces;
using MediatR;

namespace Heroes.Application.Features.Heroes.Queries.ListHeroes
{
    public class ListHeroesQueryHandler : IRequestHandler<ListHeroesQuery, List<HeroDto>>
    {
        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;

        public ListHeroesQueryHandler(IHeroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<HeroDto>> Handle(ListHeroesQuery request, CancellationToken cancellationToken)
        {
            var heroes = await _repository.GetAllAsync();
            return _mapper.Map<List<HeroDto>>(heroes);
        }
    }
}
