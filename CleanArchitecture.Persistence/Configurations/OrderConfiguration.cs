using CleanArchitecture.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Config Tables
            ConfigureOrdersTable(builder);
            ConfigureOrdersItemsTable(builder);

            //Seeds Data
            SeedsOrdersTable(builder);
        }

        #region Configure

        private void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
        {
            //Config Table Schema ------------------------------------------------
            builder.ToTable("Sales.Orders");

            //Config Primary Key
            builder.HasKey(u => u.Id);
            builder.Property(c => c.Id).HasColumnName("OrderId").ValueGeneratedOnAdd();

            //Config Columns
            builder.Property(p => p.OrderDescription).HasMaxLength(200);

            //Config Shared
            builder.OwnsOne(order => order.ShippingAddress, shippingAddressBuilder =>
            {
                shippingAddressBuilder.Property(c => c.Country).HasColumnName("Country");
                shippingAddressBuilder.Property(c => c.City).HasColumnName("City");
                shippingAddressBuilder.Property(c => c.Region).HasColumnName("Region");
                shippingAddressBuilder.Property(c => c.Street).HasColumnName("Street");
                shippingAddressBuilder.Property(c => c.Building).HasColumnName("Building");
                shippingAddressBuilder.Property(c => c.Floor).HasColumnName("Floor");
                shippingAddressBuilder.Property(c => c.Apartment).HasColumnName("Apartment");
            });

            //Config Navigation
            builder.Navigation(n=>n.OrderItems).Metadata.SetField("_orderItems");
            builder.Navigation(n => n.OrderItems).Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureOrdersItemsTable(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsMany(c => c.OrderItems, orderItemBuilder =>
            {
                //Config Table Schema ------------------------------------------------

                orderItemBuilder.ToTable("Sales.OrdersItems");

                //Config Primary Key
                orderItemBuilder.HasKey(u => u.Id);
                orderItemBuilder.Property(c => c.Id).HasColumnName("OrderItemId").ValueGeneratedOnAdd();

                //Config Foreign Keys
                orderItemBuilder.WithOwner().HasForeignKey(fk=>fk.OrderId);

                //Config Columns

                orderItemBuilder.Property(c => c.Description).HasMaxLength(200);

                orderItemBuilder.Property(p => p.AdditionsPercent).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.AdditionsValue).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.DiscountPercent).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.DiscountValue).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.Quantity).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.TaxesPercent).HasColumnType("decimal(18,5)");

                orderItemBuilder.Property(p => p.TaxesValue).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.UnitPrice).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.AdditionsPercent).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.AdditionsValue).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.DiscountPercent).HasColumnType("decimal(18,3)");

                orderItemBuilder.Property(p => p.DiscountValue).HasColumnType("decimal(18,3)");

                //Config Taxes Table
                orderItemBuilder.OwnsMany(taxes => taxes.ItemTaxes, taxesBuilder =>
                {
                    taxesBuilder.ToTable("Sales.OrdersItemsTaxes");

                    taxesBuilder.HasKey(u => u.Id);

                    taxesBuilder.Property(c => c.Id).HasColumnName("TaxId").ValueGeneratedOnAdd();

                    taxesBuilder.WithOwner().HasForeignKey(fk=>fk.OrderItemId);
                    taxesBuilder.WithOwner().HasForeignKey(fk => fk.OrderId);

                    taxesBuilder.Property(c => c.TaxName).HasMaxLength(200);
                    taxesBuilder.Property(p => p.TaxValue).HasColumnType("decimal(18,3)");
                    taxesBuilder.Property(p => p.TaxPercent).HasColumnType("decimal(18,5)");

                });

                //Config Navigation
                orderItemBuilder.Navigation(n=>n.ItemTaxes).Metadata.SetField("_itemTaxes");
                orderItemBuilder.Navigation(n => n.ItemTaxes).Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);

            });
        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsOrdersTable(EntityTypeBuilder<Order> builder)
        {
            //Seeding Data ------------------------------------------------

        }

        #endregion

    }
}
