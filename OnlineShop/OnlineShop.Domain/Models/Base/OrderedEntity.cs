namespace OnlineShop.Domain.Models.Base
{
    public record OrderedEntity : NamedEntity
    {
        public int Order { get; init; }
    }
}
