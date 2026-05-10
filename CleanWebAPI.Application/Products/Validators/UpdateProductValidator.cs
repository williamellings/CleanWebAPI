using CleanWebAPI.Application.Products.Commands;
using FluentValidation;

namespace CleanWebAPI.Application.Products.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Produktens ID krävs.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Namnet får inte vara tomt.")
            .MaximumLength(100).WithMessage("Namnet får vara max 100 tecken.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Priset måste vara högre än 0.");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("En produkt måste tillhöra en kategori.");
    }
}