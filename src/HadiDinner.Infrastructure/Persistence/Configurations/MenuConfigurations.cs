using HadiDinner.Domain.Host.ValueObjects;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.Menu.Entities;
using HadiDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HadiDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            m => m.DinnerIds,
            db =>
            {
                db.ToTable("menu_dinner_ids");

                db.Property("Id").HasColumnName("id");

                db.WithOwner().HasForeignKey("menu_id");

                db.HasKey("Id");

                db.Property(d => d.Value).HasColumnName("dinner_id").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            m => m.ReviewIds,
            mb =>
            {
                mb.ToTable("menu_review_ids");

                mb.WithOwner().HasForeignKey("menu_id");

                mb.HasKey("Id");

                mb.Property("Id").HasColumnName("id");

                mb.Property(d => d.Value).HasColumnName("review_id").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Menu.ReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            m => m.Sections,
            sb =>
            {
                sb.ToTable("menu_sections");
                sb.WithOwner().HasForeignKey("menu_id");

                sb.HasKey(nameof(MenuSection.Id), "menu_id");

                sb.Property(sb => sb.Id)
                    .HasColumnName("menu_section_id")
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value, value => MenuSectionId.Create(value));

                sb.Property(s => s.Name).HasColumnName("name").HasMaxLength(100);
                sb.Property(s => s.Description).HasColumnName("description").HasMaxLength(100);

                sb.OwnsMany(
                    s => s.Items,
                    (ib) =>
                    {
                        ib.ToTable("menu_items");
                        ib.WithOwner().HasForeignKey("menu_section_id", "menu_id");

                        ib.HasKey(nameof(MenuItem.Id), "menu_id", "menu_section_id");

                        ib.Property(i => i.Id)
                            .HasColumnName("menu_item_id")
                            .ValueGeneratedNever()
                            .HasConversion(id => id.Value, value => MenuItemId.Create(value));

                        ib.Property(s => s.Name).HasColumnName("name").HasMaxLength(100);
                        ib.Property(s => s.Description)
                            .HasColumnName("description")
                            .HasMaxLength(100);
                    }
                );

                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items)
                    .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("menus");

        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .HasColumnName("menu_id")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuId.Create(value));

        builder.Property(m => m.Name).HasColumnName("name").HasMaxLength(100);

        builder.Property(m => m.Description).HasColumnName("description").HasMaxLength(100);

        builder.OwnsOne(
            m => m.AverageRating,
            ab =>
            {
                ab.Property(a => a.Value).HasColumnName("average_rating");
                ab.Property(a => a.RatingCount).HasColumnName("rating_count");
            }
        );

        builder
            .Property(m => m.HostId)
            .HasColumnName("host_id")
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(m => m.CreatedDateTime).HasColumnName("created_at");
        builder.Property(m => m.UpdatedDateTime).HasColumnName("updated_at");
    }
}
