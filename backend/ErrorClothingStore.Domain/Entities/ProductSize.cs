using ErrorClothingStore.Domain.Common;

namespace ErrorClothingStore.Domain.Entities
{
    public class ProductSize : BaseEntity<int>, IAggregateRoot
    {
        public string Display { get; private set; }
        public string Size { get; private set; }

        public ProductSize(string display, string size)
        {
            Display = display;
            Size = size;
        }
    }
}