using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Infrastructure.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.NumberOfPeople)
                .IsRequired();

            builder.Property(r => r.CustomerId)
                .IsRequired();

            builder.Property(r => r.RestaurantId)
                .IsRequired();
        }
    }
}
