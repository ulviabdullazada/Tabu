using FluentValidation;
using Tabu.DTOs.Words;
using Tabu.Enums;

namespace Tabu.Validators.Words
{
    public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);

            RuleFor(x => x.BannedWords)
                .NotNull()
                .Must(x => x.Count() == (int)GameLevels.Hard)
                    .WithMessage((int)GameLevels.Hard + " ədəd unikal qadağan olunmuş söz yazmalısınız");

            RuleForEach(x => x.BannedWords)
                .NotNull()
                .MaximumLength(32);
        }
    }
}
