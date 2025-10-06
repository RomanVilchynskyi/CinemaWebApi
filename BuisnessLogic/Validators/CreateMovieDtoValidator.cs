using BuisnessLogic.DTOs;
using FluentValidation;

namespace BuisnessLogic.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoValidator()
        {
            RuleFor(x => x.Title)
              .NotEmpty()
              .MinimumLength(3)
              .Matches("^[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.Description)
                .MinimumLength(10)
                .MaximumLength(3000);

            RuleFor(x => x.GenreId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
