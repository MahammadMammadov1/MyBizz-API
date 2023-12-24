using FluentValidation;

namespace Mybizz.DTOs.Profession
{
    public class ProfessionUpdateDto
    {
        public string Name { get; set; }

    }
    public class ProfessionUpdateDtoValidator : AbstractValidator<ProfessionUpdateDto>
    {
        public ProfessionUpdateDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(100).WithMessage("max 100 characters.");
        }
    }
}
