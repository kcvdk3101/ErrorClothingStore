using System;

namespace ErrorClothingStore.Application.Features.Categories.ViewModels
{
    public class CategoryListVm
    {
        public Guid Id { get; init; }
        public string DisplayName { get; init; }
        public string Slug { get; init; }
    }
}