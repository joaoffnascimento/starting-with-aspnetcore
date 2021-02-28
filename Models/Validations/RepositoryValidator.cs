using FluentValidation;

namespace starting_with_aspnetcore.Models.Validations
{
    public class RepositoryValidator : AbstractValidator<Repository>
    {
        public RepositoryValidator()
        {
            // Validations here
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Enter the name of the repository!")
                .Length(3, 100).WithMessage("The name entered must be between 3 and 100 characters long!");

            RuleFor(x => x.Stars)
                .InclusiveBetween(0, 5).WithMessage("Value for stars must be between 0 and 5.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email.");
        }

        private static bool validateStars(int stars)
        {
            if (stars < 0) return false;
            if (stars > 5) return false;
            return true;
        }
    }
}