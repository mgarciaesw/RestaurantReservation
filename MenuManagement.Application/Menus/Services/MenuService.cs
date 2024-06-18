using MenuManagement.Application.Menus.Dtos;
using MenuManagement.Domain.Menus;

namespace MenuManagement.Application.Menus.Services
{
    public sealed class MenuService(IMenuRepository menuRepository)
    {
        public async Task<Menu?> GetMenuAsync(Guid id)
        {
            return await menuRepository.GetAsync(id);
        }

        public async Task DeleteMenuAsync(Guid id)
        {
            var menu = await menuRepository.GetAsync(id);
            if (menu is null)
            {
                throw new Exception("not found");
            }

            await menuRepository.DeleteAsync(menu);
        }

        public async Task<Guid> CreateMenuAsync(CreateMenuRequest request)
        {
            var menu = new Menu(
                Guid.NewGuid(),
                request.RestaurantId,
                CreateSections(request.Sections));

            await menuRepository.AddAsync(menu);

            return menu.Id;
        }

        private ICollection<MenuSection> CreateSections(IEnumerable<MenuSectionDto> sectionDtos)
        {
            return sectionDtos.Select(s => new MenuSection(
                    s.Name,
                    CreateItems(s.Items)))
                .ToList();
        }

        private ICollection<MenuItem> CreateItems(IEnumerable<MenuItemDto> itemDtos)
        {
            return itemDtos.Select(i => new MenuItem(
                    i.Name,
                    i.Description,
                    i.Price,
                    i.Currency,
                    CreateAllergens(i.Allergens)))
                .ToList();
        }

        private ICollection<Allergen> CreateAllergens(IEnumerable<string> stringAllergens)
        {
            return stringAllergens.Select(a => CreateAllergen(a))
                .ToList();
        }

        private Allergen CreateAllergen(string stringAllergen)
        {
            if (!Enum.TryParse(stringAllergen, out Allergen allergen))
            {
                throw new Exception("Invalid allergen");
            }

            return allergen;
        }
    }
}
