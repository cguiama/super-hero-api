using FluentValidation;
using Heroes.Application.Features.Heroes.Commands.CreateHero;
using Heroes.Application.Interfaces;

namespace Heroes.Application.Features.Heroes.Validators
{
    public class CreateHeroCommandValidator : AbstractValidator<CreateHeroCommand>
    {
        public CreateHeroCommandValidator(IHeroRepository repository)
        {
            RuleFor(x => x.Hero.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode ter mais de 100 caracteres.")
                .MustAsync(async (name, _) => !(await repository.ExistsByNameAsync(name)))
                .WithMessage("Já existe um herói com esse nome.");

            RuleFor(x => x.Hero.HeroName)
                .NotEmpty().WithMessage("Nome de herói é obrigatório.")
                .MaximumLength(100);

            RuleFor(x => x.Hero.BirthDate)
                .LessThan(DateTime.UtcNow).WithMessage("Data de nascimento deve ser no passado.");

            RuleFor(x => x.Hero.Height)
                .GreaterThan(0).WithMessage("Altura deve ser maior que zero.");

            RuleFor(x => x.Hero.Weight)
                .GreaterThan(0).WithMessage("Peso deve ser maior que zero.");
        }
    }
}
