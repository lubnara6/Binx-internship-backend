using FluentValidation;
using MyFirstApi.Models;

public class CreateBookRequestValidator
    : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("Title must contain at least 3 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");

        RuleFor(x => x.AuthorId)
            .GreaterThan(0)
            .WithMessage("AuthorId must be greater than 0.");
    }
}