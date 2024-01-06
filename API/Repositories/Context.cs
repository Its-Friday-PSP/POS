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
        public DbSet<ServiceTimeSlots> ServiceTimeSlot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .OwnsOne(customer => customer.Auth, auth =>
                {
                    auth.Property(auth => auth.Email).IsRequired();
                    auth.Property(auth => auth.Password).IsRequired();
                })
                .Navigation(customer => customer.Auth).IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne(order => order.ProductOrder)
                .WithOne(productOrder => productOrder.Order)
                .HasForeignKey<ProductOrder>(productOrder => productOrder.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.ServiceOrder)
                .WithOne(serviceOrder => serviceOrder.Order)
                .HasForeignKey<ServiceOrder>(serviceOrder => serviceOrder.OrderId);

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

            modelBuilder.Entity<Product>()
                .HasMany(product => product.OrderItems)
                .WithOne(orderItems => orderItems.Product)
                .HasForeignKey(orderItems => orderItems.ProductId);

            modelBuilder.Entity<Service>()
                .HasMany(service => service.ServiceTimeSlots)
                .WithOne(timeSlots => timeSlots.Service)
                .HasForeignKey(timeSlots => timeSlots.ServiceId);

            modelBuilder.Entity<ServiceTimeSlots>()
                .HasOne(timeSlots => timeSlots.Service)
                .WithMany(service => service.ServiceTimeSlots) 
                .HasForeignKey(timeSlots => timeSlots.ServiceId);
        }

    }
}
