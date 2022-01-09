using System.Collections.Generic;
using ErrorClothingStore.Application.Features.Categories.ViewModels;
using FluentValidation.Results;
using MediatR;

namespace ErrorClothingStore.Application.Features.Categories.Commands.CreateNewCategory
{
    public class CreateNewCategory : IRequest<(List<ValidationFailure> errors, CategoryDetailsVm category)>
    {
        public string DisplayName { get; init; }
    }
}