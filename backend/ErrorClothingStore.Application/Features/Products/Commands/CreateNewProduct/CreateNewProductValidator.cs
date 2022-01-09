using FluentValidation;

namespace ErrorClothingStore.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductValidator : AbstractValidator<CreateNewProduct>
    {
        public CreateNewProductValidator()
        {
            RuleFor(cnp => cnp.Title).MaximumLength(250);
            RuleFor(cnp => cnp.CategorySlug).MaximumLength(250);
            RuleFor(cnp => cnp.Price).GreaterThan(0);
        }
    }
}