using Heroes.Application.Interfaces;
using MediatR;

namespace Heroes.Application.Features.Heroes.Commands.DeleteHero
{
    public class DeleteHeroCommandHandler : IRequestHandler<DeleteHeroCommand, Unit>
    {
        private readonly IHeroRepository _repository;

        public DeleteHeroCommandHandler(IHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = await _repository.GetByIdAsync(request.Id);

            if (hero == null)
                throw new Exception("Herói não encontrado.");

            await _repository.DeleteAsync(hero);

            return Unit.Value;
        }
    }
}
