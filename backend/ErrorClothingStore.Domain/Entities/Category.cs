using System;
using ErrorClothingStore.Domain.Common;

namespace ErrorClothingStore.Domain.Entities
{
    public class Category : BaseEntity<Guid>, IAggregateRoot
    {
        public string DisplayName { get; private set; }
        public string Slug { get; private set; }

        public Category(string displayName, string slug)
        {
            DisplayName = displayName;
            Slug = slug;
        }
    }
}