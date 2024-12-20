using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
    public class LanguageUpdateDtoValidator : AbstractValidator<LanguageUpdateDto>
    {
        public LanguageUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Name bosh ola bilmez")
                .MaximumLength(64)
                    .WithMessage("Name uzunluğu 64-dən artıq ola bilməz");

            RuleFor(x => x.Icon)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Icon bosh ola bilmez")
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                    .WithMessage("Icon deyeri link olmalidir")
                .MaximumLength(128)
                    .WithMessage("Icon uzunluğu 128-dən artıq ola bilməz");
        }
    }
}
