using System;
using DAL.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AirLine_Reseravtion_Project.Db
{
    public partial class airlinereservationDatabaseContext : DbContext
    {
        public airlinereservationDatabaseContext()
        {
        }

        public airlinereservationDatabaseContext(DbContextOptions<airlinereservationDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<PassengersDetail> PassengersDetails { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<SignUp> SignUps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-ASN08A5\\MSSQLSERVER01;Initial Catalog=airline-reservation-Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("booking-details");

                entity.Property(e => e.FlightId).HasColumnName("flightId");

                entity.Property(e => e.ArrivalCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("arrival_city");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnType("datetime")
                    .HasColumnName("arrival_time");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.DepartureCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("departure_city");

                entity.Property(e => e.DepartureTime)
                    .HasColumnType("datetime")
                    .HasColumnName("departure_time");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<PassengersDetail>(entity =>
            {
                entity.HasKey(e => e.PassengerId);

                entity.ToTable("passengers-details");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.ReservationDate)
                    .HasColumnType("date")
                    .HasColumnName("reservation_date");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_Reservations_booking-details");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.PassengerId)
                    .HasConstraintName("FK_Reservations_passengers-details");
            });

            modelBuilder.Entity<SignUp>(entity =>
            {
                entity.ToTable("SignUp");

                entity.HasIndex(e => e.Email, "UQ_Email")
                    .IsUnique();

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
