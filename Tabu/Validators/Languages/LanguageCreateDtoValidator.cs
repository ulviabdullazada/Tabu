using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Code bosh ola bilmez")
                .MaximumLength(2)
                    .WithMessage("Code uzunluğu 2-dən artıq ola bilməz");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Name bosh ola bilmez")
                .MaximumLength(64)
                    .WithMessage("Name uzunluğu 64-dən artıq ola bilməz");

            RuleFor(x => x.IconUrl)
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
