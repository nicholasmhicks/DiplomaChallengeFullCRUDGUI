namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewModel : DbContext
    {
        public NewModel()
            : base("name=NewModel")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TourEvent> TourEvents { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<BookingsView> BookingsViews { get; set; }
        public virtual DbSet<ClientView> ClientViews { get; set; }
        public virtual DbSet<TourEventView> TourEventViews { get; set; }
        public virtual DbSet<TourView> TourViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourEvent>()
                .Property(e => e.Fee)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourEvent>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.TourEvent)
                .HasForeignKey(e => new { e.EventMonth, e.EventDay, e.EventYear });

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.TourEvents)
                .WithRequired(e => e.Tour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookingsView>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourEventView>()
                .Property(e => e.Fee)
                .HasPrecision(19, 4);
        }
    }
}
