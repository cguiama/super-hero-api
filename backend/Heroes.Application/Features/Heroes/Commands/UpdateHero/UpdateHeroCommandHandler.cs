using AutoMapper;
using Heroes.Application.Features.Heroes.Dtos;
using Heroes.Application.Interfaces;
using Heroes.Domain.Entities;
using MediatR;

namespace Heroes.Application.Features.Heroes.Commands.UpdateHero
{
    public class UpdateHeroCommandHandler : IRequestHandler<UpdateHeroCommand, HeroDto>
    {
        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;

        public UpdateHeroCommandHandler(IHeroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HeroDto> Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Hero;
            var hero = await _repository.GetByIdAsync(dto.Id);

            if (hero == null)
                throw new Exception("Herói não encontrado.");

            hero.Update(dto.Name!, dto.HeroName!, dto.BirthDate.ToUniversalTime(), dto.Height, dto.Weight);

            hero.ClearPowers();
            if (dto.SuperPowerIds is not null)
            {
                foreach (var id in dto.SuperPowerIds)
                    hero.AddPower(new HeroSuperPower(hero.Id, id));
            }

            await _repository.UpdateAsync(hero);
            return _mapper.Map<HeroDto>(hero);
        }
    }
}
