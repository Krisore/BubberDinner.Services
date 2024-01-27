using BubberDinner.Contract.Menus.Request;
using BubberDinner.Domain.HostAggregate.ValueObjects;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.Models.MenuAggregate;
using BubberDinner.Domain.Models.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubberDinner.Infrastructure.Persistent.Configuration;


public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenusSectionTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, dib =>
        {
            dib.ToTable("MenuReviewIds");

            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");

            dib.Property(d => d.Value)
            .HasColumnName("ReviewId")
            .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");

            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");

            dib.Property(d => d.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusSectionTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuSections, sb =>
        {
            sb.ToTable("MenusSections");
            sb.WithOwner().HasForeignKey("MenuId");
            sb.HasKey("Id", "MenuId");
            sb.Property(ms => ms.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuSectionId.Create(value)
            );

            sb.Property(ms => ms.Name).HasMaxLength(100);
            sb.Property(ms => ms.Description).HasMaxLength(100);

            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");
                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                ib.HasKey(nameof(BubberDinner.Domain.MenuAggregate.Entities.MenuItem.Id), "MenuSectionId", "MenuId");
                ib.Property(ms => ms.Id)
                .HasColumnName("MenuItemId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.Create(value)
                );
                ib.Property(ms => ms.Name).HasMaxLength(100);
                ib.Property(ms => ms.Description).HasMaxLength(100);
            });
            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuSections))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                value => MenuId.Create(value));

        builder.Property(m => m.Name)
        .HasMaxLength(100);
        builder.Property(m => m.Description)
        .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);
        builder.Property(m => m.HostId)
                .HasConversion(id => id.Value,
                value => HostId.Create(value));

    }
}
