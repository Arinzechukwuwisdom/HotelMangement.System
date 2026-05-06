using HotelManagementSystem.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.API.Context
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options):base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotels");

                entity.HasIndex(h => new { h.City, h.Country });

                entity.HasMany(h => h.Employees)
                      .WithOne(e => e.Hotel)
                      .HasForeignKey(e => e.HotelId)
                      .OnDelete(DeleteBehavior.Restrict);

                //entity.HasMany(h => h.Rooms)
                //      .WithOne(r => r.Hotel)
                //      .HasForeignKey(r => r.HotelId)
                //      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Room>(entity=>
            {
                entity.ToTable("Rooms");

                entity.Property(r => r.RoomStatus)
                .HasConversion<string>();

                entity.Property(r=>r.RoomType)
                .HasConversion<string>();

                entity.HasMany(b => b.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(r => r.RoomId);
            });

            modelBuilder.Entity<Customer>(entity=>  
            {
                entity.ToTable("Customers");

                entity.HasMany(h => h.Bookings)
                      .WithOne(e => e.Customer)
                      .HasForeignKey(e => e.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
