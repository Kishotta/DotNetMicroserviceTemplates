using Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Persistence.Configurations;

internal sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure (EntityTypeBuilder<Car> builder)
    {
        builder.HasKey (car => car.Id);
    }
}