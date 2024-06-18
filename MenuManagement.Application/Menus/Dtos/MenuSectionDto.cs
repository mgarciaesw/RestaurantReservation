namespace MenuManagement.Application.Menus.Dtos
{
    public sealed record MenuSectionDto(
        string Name,
        IEnumerable<MenuItemDto> Items);
}
