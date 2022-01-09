namespace ErrorClothingStore.Domain.Common
{
    public class BaseEntity<TId>
    {
        public TId Id { get; private set; }
    }
}