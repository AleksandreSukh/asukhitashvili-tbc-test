using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;

namespace Test.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonalConnection> ConnectedPersons { get; set; }
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public virtual DbSet<ConnectionType> ConnectionTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Model level validations on Person table
            modelBuilder.Entity<Person>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Person>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.Surname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.Gender)
                .HasMaxLength(5)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.IdNumber)
                .HasMaxLength(11)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.BirthDate)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasOne(e => e.City)
                .WithMany()
                .HasForeignKey(e => e.CityId)
                .IsRequired(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Picture)
                .HasMaxLength(256)
                .IsRequired(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PhoneNumbers)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            //Configure self-referencing many to many relationship using PersonalConnection entity
            modelBuilder.Entity<Person>()
                .HasMany(e => e.ConnectionsTo)
                .WithOne(e => e.From)
                .HasForeignKey(e => e.FromId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.ConnectionsFrom)
                .WithOne(e => e.To)
                .HasForeignKey(e => e.ToId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonalConnection>()
                .HasKey(e => new { e.FromId, e.ToId });

            modelBuilder.Entity<PersonalConnection>()
                .HasOne(e => e.ConnectionType)
                .WithMany()
                .HasForeignKey(e => e.ConnectionTypeId);

            modelBuilder.Entity<PersonalConnection>()
                .HasOne(e => e.From)
                .WithMany(e => e.ConnectionsTo)
                .HasForeignKey(e => e.FromId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalConnection>()
                .HasOne(e => e.To)
                .WithMany(e => e.ConnectionsFrom)
                .HasForeignKey(e => e.ToId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhoneNumber>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<PhoneNumber>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<PhoneNumber>()
                .HasOne(e => e.Type)
                .WithMany()
                .HasForeignKey(e => e.TypeId)
                .IsRequired();

            modelBuilder.Entity<PhoneNumber>()
                .Property(e => e.Number)
                .HasMaxLength(50);

            modelBuilder.Entity<PhoneNumberType>()
                        .HasKey(e => e.Id);

            modelBuilder.Entity<ConnectionType>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<City>()
                .HasKey(e => e.Id);
        }
    }
}
