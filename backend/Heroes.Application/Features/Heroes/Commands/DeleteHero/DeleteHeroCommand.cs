using MediatR;

namespace Heroes.Application.Features.Heroes.Commands.DeleteHero
{
    public class DeleteHeroCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeleteHeroCommand(Guid id)
        {
            Id = id;
        }
    }
}
