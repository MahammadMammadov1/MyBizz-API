using FluentValidation;
using System.Data;

namespace Mybizz.DTOs.Profession
{
    public class ProfessionCreateDto
    {
        public string Name { get; set; }
    }

    public class ProfessionCreateDtoValidator : AbstractValidator<ProfessionCreateDto>
    {
        public ProfessionCreateDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(100).WithMessage("max 100 characters.");
        }
    }
}
