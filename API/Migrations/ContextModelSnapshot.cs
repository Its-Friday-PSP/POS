﻿// <auto-generated />
using System;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("API.Model.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("StripeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("API.Model.CustomerDiscount", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiscountId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomerDiscount");
                });

            modelBuilder.Entity("API.Model.Discount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("ApplicableOrderType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DiscountType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsStackable")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Percentage")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("API.Model.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Order");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("API.Model.OrderItem", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId", "Index");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("API.Model.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("API.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("AmountInStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("OriginCountry")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StripeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Model.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ServiceOrderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StripeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("API.Model.ServiceTimeSlots", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceTimeSlots");
                });

            modelBuilder.Entity("API.Model.ProductOrder", b =>
                {
                    b.HasBaseType("API.Model.Order");

                    b.HasDiscriminator().HasValue("ProductOrder");
                });

            modelBuilder.Entity("API.Model.ServiceOrder", b =>
                {
                    b.HasBaseType("API.Model.Order");

                    b.HasDiscriminator().HasValue("ServiceOrder");
                });

            modelBuilder.Entity("API.Model.Customer", b =>
                {
                    b.OwnsOne("API.Model.Auth", "Auth", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Auth")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.CustomerDiscount", b =>
                {
                    b.HasOne("API.Model.Customer", "Customer")
                        .WithMany("CustomerDiscounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Discount", "Discount")
                        .WithMany("CustomerDiscounts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Order", null)
                        .WithMany("OrderDiscounts")
                        .HasForeignKey("OrderId");

                    b.Navigation("Customer");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("API.Model.Discount", b =>
                {
                    b.OwnsOne("API.Model.Price", "Price", b1 =>
                        {
                            b1.Property<string>("DiscountId")
                                .HasColumnType("TEXT");

                            b1.Property<long>("Amount")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Amount");

                            b1.Property<int>("Currency")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Currency");

                            b1.HasKey("DiscountId");

                            b1.ToTable("Discounts");

                            b1.WithOwner()
                                .HasForeignKey("DiscountId");
                        });

                    b.Navigation("Price");
                });

            modelBuilder.Entity("API.Model.Employee", b =>
                {
                    b.OwnsOne("API.Model.Auth", "Auth", b1 =>
                        {
                            b1.Property<Guid>("EmployeeId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Auth")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.Order", b =>
                {
                    b.OwnsOne("API.Model.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("TEXT");

                            b1.Property<long>("Amount")
                                .HasColumnType("INTEGER")
                                .HasColumnName("OrderAmount");

                            b1.Property<int>("Currency")
                                .HasColumnType("INTEGER")
                                .HasColumnName("OrderCurrency");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("API.Model.Tip", "Tip", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("PaymentType")
                                .HasColumnType("INTEGER")
                                .HasColumnName("TipPaymentType");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");

                            b1.OwnsOne("API.Model.Price", "Price", b2 =>
                                {
                                    b2.Property<Guid>("TipOrderId")
                                        .HasColumnType("TEXT");

                                    b2.Property<long>("Amount")
                                        .HasColumnType("INTEGER")
                                        .HasColumnName("TipAmount");

                                    b2.Property<int>("Currency")
                                        .HasColumnType("INTEGER")
                                        .HasColumnName("TipCurrency");

                                    b2.HasKey("TipOrderId");

                                    b2.ToTable("Orders");

                                    b2.WithOwner()
                                        .HasForeignKey("TipOrderId");
                                });

                            b1.Navigation("Price")
                                .IsRequired();
                        });

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("API.Model.OrderItem", b =>
                {
                    b.HasOne("API.Model.ProductOrder", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Model.Payment", b =>
                {
                    b.HasOne("API.Model.Order", null)
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("API.Model.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("PaymentId")
                                .HasColumnType("TEXT");

                            b1.Property<long>("Amount")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Amount");

                            b1.Property<int>("Currency")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Currency");

                            b1.HasKey("PaymentId");

                            b1.ToTable("Payments");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.Product", b =>
                {
                    b.OwnsOne("API.Model.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<long>("Amount")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Amount");

                            b1.Property<int>("Currency")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Currency");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Price");
                });

            modelBuilder.Entity("API.Model.Service", b =>
                {
                    b.HasOne("API.Model.ServiceOrder", null)
                        .WithMany("Services")
                        .HasForeignKey("ServiceOrderId");

                    b.OwnsOne("API.Model.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("ServiceId")
                                .HasColumnType("TEXT");

                            b1.Property<long>("Amount")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Pay");

                            b1.Property<int>("Currency")
                                .HasColumnType("INTEGER")
                                .HasColumnName("Currency");

                            b1.HasKey("ServiceId");

                            b1.ToTable("Services");

                            b1.WithOwner()
                                .HasForeignKey("ServiceId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.ServiceTimeSlots", b =>
                {
                    b.HasOne("API.Model.Employee", null)
                        .WithMany("ServiceTimeSlots")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Service", null)
                        .WithMany("ServiceTimeSlots")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.Customer", b =>
                {
                    b.Navigation("CustomerDiscounts");
                });

            modelBuilder.Entity("API.Model.Discount", b =>
                {
                    b.Navigation("CustomerDiscounts");
                });

            modelBuilder.Entity("API.Model.Employee", b =>
                {
                    b.Navigation("ServiceTimeSlots");
                });

            modelBuilder.Entity("API.Model.Order", b =>
                {
                    b.Navigation("OrderDiscounts");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("API.Model.Service", b =>
                {
                    b.Navigation("ServiceTimeSlots");
                });

            modelBuilder.Entity("API.Model.ProductOrder", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("API.Model.ServiceOrder", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
