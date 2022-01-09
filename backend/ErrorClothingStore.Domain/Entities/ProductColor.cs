using ErrorClothingStore.Domain.Common;

namespace ErrorClothingStore.Domain.Entities
{
    public class ProductColor : BaseEntity<int>, IAggregateRoot
    {
        public string Display { get; private set; }
        public string Color { get; private set; }

        public ProductColor(string display, string color)
        {
            Display = display;
            Color = color;
        }
    }
}