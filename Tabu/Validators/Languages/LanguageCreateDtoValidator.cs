using FluentValidation;
using Tabu.DTOs.Languages;
using Tabu.ExternalServices.Abstracts;
using Tabu.Helpers;

namespace Tabu.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        readonly IErrorService _service;
        public LanguageCreateDtoValidator(IErrorService service)
        {
            _service = service;
            RuleFor(x => x.Code)
                .NotNull()
                    .WithMessage(_service.GetMessage(ErrorCodes.Null))
                .NotEmpty()
                    .WithMessage(_service.GetMessage(ErrorCodes.Empty))
                .MaximumLength(2)
                    .WithMessage(_service.GetMessage(ErrorCodes.LessThan, 2));

            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage(_service.GetMessage(ErrorCodes.Null))
                .NotEmpty()
                    .WithMessage(_service.GetMessage(ErrorCodes.Empty))
                .MaximumLength(64)
                    .WithMessage(_service.GetMessage(ErrorCodes.LessThan, 64));

            RuleFor(x => x.IconUrl)
                .NotNull()
                    .WithMessage(_service.GetMessage(ErrorCodes.Null))
                .NotEmpty()
                    .WithMessage(_service.GetMessage(ErrorCodes.Empty))
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                    .WithMessage(_service.GetMessage(ErrorCodes.Format))
                .MaximumLength(128)
                    .WithMessage(_service.GetMessage(ErrorCodes.LessThan, 128));

        }
    }
}
