using FluentValidation;
using MyFirstApi.Models;

namespace MyFirstApi.Validators;

public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(100)
            .WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");





        RuleFor(x => x.AuthorId)
            .GreaterThan(0)
            .WithMessage("AuthorId must be greater than 0.");
    }
}