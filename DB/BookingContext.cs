using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Booking;
using Booking.Models;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.DB {
    public class BookingContext : DbContext {
        public BookingContext (DbContextOptions<BookingContext> options) : base (options) { }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClientAppointment> ClientAppointments { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            // ...
            var cascadeFKs = modelBuilder.Model.GetEntityTypes ()
                .SelectMany (t => t.GetForeignKeys ())
                .Where (fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<ClientAppointment> ()
                .HasOne<Client> (sc => sc.Client)
                .WithMany (s => s.ClientAppointments);

            modelBuilder.Entity<ClientAppointment> ()
                .HasOne<Appointment> (sc => sc.Appointment)
                .WithMany (s => s.ClientAppointments);

        }
        public override int SaveChanges (bool acceptAllChangesOnSuccess) {
            OnBeforeSaving ();
            return base.SaveChanges (acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default (CancellationToken)) {
            OnBeforeSaving ();
            return base.SaveChangesAsync (acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving () {
            var entries = ChangeTracker.Entries ();
            foreach (var entry in entries) {
                if (entry.Entity is BaseModel) {
                    var now = DateTime.UtcNow;
                    BaseModel entity = (BaseModel) entry.Entity;
                    switch (entry.State) {
                        case EntityState.Modified:
                            entity.UpdatedAt = now;
                            break;
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            break;
                    }
                }
            }
        }
    }
}