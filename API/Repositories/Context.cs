using API.Model;
using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ServiceTimeSlots> ServiceTimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnCreatingOrder(modelBuilder);
            OnCreatingPayments(modelBuilder);
            OnCreatingDiscount(modelBuilder);
            OnCreatingService(modelBuilder);
            OnCreatingCustomer(modelBuilder);
            OnCreatingProduct(modelBuilder);

            modelBuilder.Entity<Employee>()
               .OwnsOne(employee => employee.Auth, auth =>
               {
                   auth.Property(auth => auth.Email).IsRequired();
                   auth.Property(auth => auth.Password).IsRequired();
               })
               .Navigation(employee => employee.Auth).IsRequired();

            modelBuilder.Entity<Employee>()
               .HasMany(employee => employee.ServiceTimeSlots)
               .WithOne()
               .HasForeignKey(serviceTimeSlots => serviceTimeSlots.EmployeeId);

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasKey(a => a.Id);

        }

        private void OnCreatingProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .OwnsOne(product => product.Price, price =>
                {
                    price.Property(price => price.Amount).HasColumnName("Price");
                    price.Property(price => price.Currency).HasColumnName("Currency");
                });
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

        }

        private void OnCreatingDiscount(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>()
                .OwnsOne(discount => discount.Price, price =>
                {
                    price.Property(price => price.Amount).HasColumnName("Amount");
                    price.Property(price => price.Currency).HasColumnName("Currency");
                });

            modelBuilder.Entity<CustomerDiscount>()
                .HasKey(cd => new { cd.CustomerId, cd.DiscountId });

            modelBuilder.Entity<CustomerDiscount>()
                .HasOne(cd => cd.Customer)
                .WithMany(c => c.CustomerDiscounts)
                .HasForeignKey(cd => cd.CustomerId);

            modelBuilder.Entity<CustomerDiscount>()
                .HasOne(cd => cd.Discount)
                .WithMany(d => d.CustomerDiscounts)
                .HasForeignKey(cd => cd.DiscountId);
        }

        private void OnCreatingOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .OwnsOne(product => product.Price, price =>
                {
                    price.Property(price => price.Amount).HasColumnName("OrderAmount");
                    price.Property(price => price.Currency).HasColumnName("OrderCurrency");
                });

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

            modelBuilder.Entity<OrderItem>()
                .HasKey(item => new { item.OrderId, item.Id, item.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(orderItem => orderItem.ProductOrder)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(order => order.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(orderItem => orderItem.ProductId);
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
               .HasMany(service => service.ServiceTimeSlots)
               .WithOne()
               .HasForeignKey(serviceTimeSlots => serviceTimeSlots.Id);

            modelBuilder.Entity<Service>()
                .OwnsOne(service => service.Price, price =>
                {
                    price.Property(price => price.Amount).HasColumnName("Pay");
                    price.Property(price => price.Currency).HasColumnName("Currency");
                });

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne<Service>()
                .WithMany(service => service.ServiceTimeSlots)
                .HasForeignKey(servicetimeslots => servicetimeslots.ServiceId);

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne<Employee>()
                .WithMany(service => service.ServiceTimeSlots)
                .HasForeignKey(servicetimeslots => servicetimeslots.EmployeeId);

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne<Customer>()
                .WithMany(customer => customer.ServiceTimeSlots)
                .HasForeignKey(serviceTimeSlots => serviceTimeSlots.CustomerId);
        }
    }
}
