namespace MenuManagement.Domain.Menus
{
    public sealed class Menu
    {
        public Guid Id { get; }
        public int RestaurantId { get; }
        public ICollection<MenuSection> Sections { get; }

        public Menu(
            Guid id,
            int restaurantId,
            ICollection<MenuSection> sections)
        {
            Id = id;
            RestaurantId = restaurantId;
            Sections = sections;
        }
    }
}
