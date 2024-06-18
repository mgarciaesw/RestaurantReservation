namespace MenuManagement.Domain.Menus
{
    public sealed class MenuSection
    {
        public string Name { get; }
        public ICollection<MenuItem> Items { get; }

        public MenuSection(
            string name,
            ICollection<MenuItem> items)
        {
            Name = name;
            Items = items;
        }
    }
}
