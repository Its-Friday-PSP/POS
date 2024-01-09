﻿using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnCreatingOrder(modelBuilder);
            OnCreatingPayments(modelBuilder);
            OnCreatingDiscount(modelBuilder);
            OnCreatingService(modelBuilder);
            OnCreatingCustomer(modelBuilder);

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne<Service>()
                .WithMany(service => service.ServiceTimeSlots)
                .HasForeignKey(erviceTimeSlots => erviceTimeSlots.ServiceId);
        }

        private void OnCreatingCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .OwnsOne(customer => customer.Auth, auth =>
                {
                    auth.Property(auth => auth.Email).IsRequired();
                    auth.Property(auth => auth.Password).IsRequired();
                })
                .Navigation(customer => customer.Auth).IsRequired();

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Discounts)
                .WithOne()
                .HasForeignKey(d => d.Id);
        }

        private void OnCreatingDiscount(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>()
                .OwnsOne(discount => discount.Price, price =>
                {
                    price.Property(price => price.Amount).HasColumnName("Amount");
                    price.Property(price => price.Currency).HasColumnName("Currency");
                });
        }

        private void OnCreatingOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .OwnsOne(order => order.Tip, tipNavigation =>
                {
                    tipNavigation.OwnsOne(tip => tip.Price, priceNavigation =>
                    {
                        priceNavigation.Property(price => price.Amount).HasColumnName("TipAmount");
                        priceNavigation.Property(price => price.Currency).HasColumnName("TipCurrency");
                    });

                    tipNavigation.Property(tip => tip.PaymentType).HasColumnName("TipPaymentType");
                });

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Discounts)
                .WithOne()
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<OrderItem>()
                .HasKey(z => new
                {
                    z.OrderId,
                    z.Index
                });

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.ProductId).IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.Amount).IsRequired();

            modelBuilder.Entity<OrderItem>()
                .HasOne(orderItem => orderItem.Product)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.ProductId);

            modelBuilder.Entity<OrderItem>()
               .HasOne(orderItem => orderItem.Order)
               .WithMany(order => order.OrderItems)
               .HasForeignKey(orderItem => orderItem.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId);

            modelBuilder.Entity<ServiceOrder>()
                .HasMany(serviceOrder => serviceOrder.Services)
                .WithOne(service => service.ServiceOrder)
                .HasForeignKey(service => service.ServiceOrderId);
        }

        private void OnCreatingPayments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasOne<Order>() // Each Payment is associated with one Order
                .WithMany(order => order.Payments) // Each Order can have many Payments
                .HasForeignKey(payment => payment.OrderId);

            modelBuilder.Entity<Payment>()
                .OwnsOne(payment => payment.Price, price =>
                {
                    price.Property(price => price.Amount).HasColumnName("Amount");
                    price.Property(price => price.Currency).HasColumnName("Currency");
                });
        }

        private void OnCreatingService(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .OwnsOne(discount => discount.Price, price =>
                {
                    price.Property(price => price.Amount).HasColumnName("Amount");
                    price.Property(price => price.Currency).HasColumnName("Currency");
                });
        }
    }
}
