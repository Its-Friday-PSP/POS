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

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne<Service>()
                .WithMany(service => service.ServiceTimeSlots)
                .HasForeignKey(erviceTimeSlots => erviceTimeSlots.ServiceId);
        }

    }
}
