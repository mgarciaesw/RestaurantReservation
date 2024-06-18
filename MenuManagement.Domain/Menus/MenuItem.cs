namespace MenuManagement.Domain.Menus
{
    public sealed class MenuItem
    {
        public string Name { get; }
        public string? Description { get; }
        public decimal Price { get; }
        public string Currency { get; }
        public ICollection<Allergen> Allergens { get; }

        public MenuItem(
            string name,
            string? description,
            decimal price,
            string currency,
            ICollection<Allergen> allergens)
        {
            Name = name;
            Description = description;
            Price = price;
            Currency = currency;
            Allergens = allergens;
        }
    }
}
