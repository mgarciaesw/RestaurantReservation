using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuManagement.Application.Menus.Dtos
{
    public sealed record MenuItemDto(
        string Name,
        string? Description,
        decimal Price,
        string Currency,
        IEnumerable<string> Allergens);
}
