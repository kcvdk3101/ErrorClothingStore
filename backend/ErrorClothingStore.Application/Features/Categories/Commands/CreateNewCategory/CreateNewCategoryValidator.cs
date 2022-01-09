using FluentValidation;

namespace ErrorClothingStore.Application.Features.Categories.Commands.CreateNewCategory
{
    public class CreateNewCategoryValidator : AbstractValidator<CreateNewCategory>
    {
        public CreateNewCategoryValidator()
        {
            RuleFor(cnc => cnc.DisplayName).MaximumLength(250);
        }
    }
}