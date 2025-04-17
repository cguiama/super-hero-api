using FluentValidation;
using Heroes.Application.Interfaces;

namespace Heroes.Application.Features.Heroes.Commands.UpdateHero
{
    public class UpdateHeroCommandValidator : AbstractValidator<UpdateHeroCommand>
    {
        public UpdateHeroCommandValidator(IHeroRepository repository)
        {
            RuleFor(x => x.Hero.Name)
            .NotEmpty()
            .MustAsync(async (command, name, _) =>
            {
                var existingHero = await repository.GetByNameAsync(name!);
                return existingHero == null || existingHero.Id == command.Hero.Id;
            })
            .WithMessage("Já existe um herói com esse nome.");


            RuleFor(x => x.Hero.BirthDate)
                .LessThan(DateTime.UtcNow);

            RuleFor(x => x.Hero.Height)
                .GreaterThan(0);

            RuleFor(x => x.Hero.Weight)
                .GreaterThan(0);
        }
    }
}
