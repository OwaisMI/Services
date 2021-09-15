using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Services.Models.WorkModels
{
    public partial class WorkContext : DbContext
    {
        public WorkContext()
        {
        }

        public WorkContext(DbContextOptions<WorkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessActivity> BusinessActivtiy { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<ProjectRole> ProjectRole { get; set; }
        public virtual DbSet<Socials> Socials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Work;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessActivity>(entity =>
            {
                entity.HasKey(e => e.BusinessId);

                entity.ToTable("Business_activtiy");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasColumnName("activity_name")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.BusinessActivtiy)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_activtiy_Companies");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("city_name")
                    .HasMaxLength(2555);

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasColumnName("branch")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Number).HasColumnName("number");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("country_code")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.Property(e => e.LicenseId).HasColumnName("license_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.LicenseNumber).HasColumnName("license_number");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.POBox)
                    .IsRequired()
                    .HasColumnName("p.o_box")
                    .HasMaxLength(255);

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasColumnName("street_number")
                    .HasMaxLength(255);

                entity.Property(e => e.ZipCode).HasColumnName("zip_code");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Cities");
            });

            modelBuilder.Entity<ProjectRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Socials>(entity =>
            {
                entity.HasKey(e => e.SocialId);

                entity.Property(e => e.SocialId).HasColumnName("social_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.SocialName)
                    .IsRequired()
                    .HasColumnName("social_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Socials)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Socials_Companies");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
