using AutoMapper;
using Heroes.Application.Features.Heroes.Dtos;
using Heroes.Application.Interfaces;
using Heroes.Domain.Entities;
using MediatR;

namespace Heroes.Application.Features.Heroes.Commands.CreateHero
{
    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, HeroDto>
    {
        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;

        public CreateHeroCommandHandler(IHeroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HeroDto> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Hero;

            var hero = new Hero(
                dto.Name!,
                dto.HeroName!,
                dto.BirthDate.ToUniversalTime(),
                dto.Height,
                dto.Weight
            );

            if (dto.SuperPowerIds is not null)
            {
                foreach (var powerId in dto.SuperPowerIds)
                {
                    hero.AddPower(new HeroSuperPower(hero.Id, powerId));
                }
            }

            await _repository.AddAsync(hero);

            return _mapper.Map<HeroDto>(hero);
        }
    }
}
