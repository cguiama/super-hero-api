using AutoMapper;
using Heroes.Application.Features.Heroes.Dtos;
using Heroes.Application.Interfaces;
using MediatR;

namespace Heroes.Application.Features.Heroes.Queries.GetHeroById
{
    public class GetHeroByIdQueryHandler : IRequestHandler<GetHeroByIdQuery, HeroDto>
    {
        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;

        public GetHeroByIdQueryHandler(IHeroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HeroDto> Handle(GetHeroByIdQuery request, CancellationToken cancellationToken)
        {
            var hero = await _repository.GetByIdAsync(request.Id);
            return hero != null ? _mapper.Map<HeroDto>(hero) : null!;
        }
    }
}
