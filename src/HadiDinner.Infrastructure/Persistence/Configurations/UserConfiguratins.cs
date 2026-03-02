using HadiDinner.Domain.User;
using HadiDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HadiDinner.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnName("id")
            .HasConversion((Id) => Id.Value, (value) => UserId.Create(value));

        builder.Property(u => u.FirstName).HasColumnName("first_name").HasMaxLength(100);

        builder.Property(u => u.LastName).HasColumnName("last_name").HasMaxLength(100);

        builder.Property(u => u.Email).HasColumnName("email");

        builder
            .Property(u => u.Password)
            .HasColumnName("password_hash")
            .HasField("_passwordHash")
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(u => u.CreatedDateTime).HasColumnName("created_at");
        builder.Property(u => u.UpdatedDateTime).HasColumnName("updated_at");
    }
}
