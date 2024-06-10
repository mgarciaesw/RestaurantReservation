using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Services.RestaurantServices
{
    public sealed record NewRestaurantRequest(string Name, int MaxNumberOfSeats);
}
