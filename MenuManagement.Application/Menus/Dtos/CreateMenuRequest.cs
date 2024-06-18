namespace MenuManagement.Application.Menus.Dtos
{
    public sealed record CreateMenuRequest(
        int RestaurantId,
        IEnumerable<MenuSectionDto> Sections);
}
