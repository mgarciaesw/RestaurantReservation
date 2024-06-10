using ReservationManagement.Application.Services;
using ReservationManagement.Application.Request;

namespace ReservationManagement.API.RouteHandlerExtensions
{
    public static class APIRouteHandler
    {
        public static void AddMinimalAPIRouteHandlerMappings(this WebApplication app)
        {
            app.MapGet("/reservation/{reservationId}", (ManageReservationService service, int reservationId) =>
            {
                return service.GetReservationByIdAsync(reservationId);
            })
            .WithName("GetReservationById")
            .WithOpenApi();

            app.MapPost("/reservation", (ManageReservationService service, CreateReservationRequest request) =>
            {
                return service.CreateReservationAsync(request);
            })
            .WithName("CreateReservation")
            .WithOpenApi();

            app.MapDelete("/reservation/{reservationId}", (ManageReservationService service, int reservationId) =>
            {
                return service.DeleteReservationAsync(reservationId);
            })
            .WithName("DeleteReservation")
            .WithOpenApi();
        }
    }
}
