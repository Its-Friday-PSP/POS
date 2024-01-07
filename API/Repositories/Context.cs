using API.Model;
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
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .OwnsOne(customer => customer.Auth, auth =>
                {
                    auth.Property(auth => auth.Email).IsRequired();
                    auth.Property(auth => auth.Password).IsRequired();
                })
                .Navigation(customer => customer.Auth).IsRequired();

            modelBuilder.Entity<ProductOrder>()
                .HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId);

            modelBuilder.Entity<ServiceOrder>()
                .HasMany(serviceOrder => serviceOrder.Services) 
                .WithOne(service => service.ServiceOrder) 
                .HasForeignKey(service => service.ServiceOrderId); 

            modelBuilder.Entity<Employee>()
               .OwnsOne(employee => employee.Auth, auth =>
               {
                   auth.Property(auth => auth.Email).IsRequired();
                   auth.Property(auth => auth.Password).IsRequired();
               })
               .Navigation(employee => employee.Auth).IsRequired();

            modelBuilder.Entity<OrderItem>()
                .HasKey(z => new
                {
                    z.OrderId,
                    z.Index,
                });

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.ProductId).IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.Amount).IsRequired();

            modelBuilder.Entity<OrderItem>()
                .HasOne(orderItem => orderItem.Product)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.ProductId);

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

            modelBuilder.Entity<OrderItem>()
                .HasOne(orderItem => orderItem.Order)
                .WithMany(order => order.OrderItems) 
                .HasForeignKey(orderItem => orderItem.OrderId);

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne<Service>()
                .WithMany(service => service.ServiceTimeSlots)
                .HasForeignKey(erviceTimeSlots => erviceTimeSlots.ServiceId);

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne<Employee>()
                .WithMany(employee => employee.ServiceTimeSlots)
                .HasForeignKey(erviceTimeSlots => erviceTimeSlots.EmployeeId);

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
        }
    }
}
