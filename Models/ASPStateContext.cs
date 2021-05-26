using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InspectionApp.Models
{
    public partial class ASPStateContext : DbContext
    {
        public ASPStateContext()
        {
        }

        public ASPStateContext(DbContextOptions<ASPStateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VehicleInspection> VehicleInspections { get; set; }
        public virtual DbSet<VehicleMaker> VehicleMakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=dsSCSMdev01;Database=ASPState;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

           
            modelBuilder.Entity<VehicleInspection>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Vehicle_Inspection");

                entity.ToTable("VehicleInspection");

                entity.Property(e => e.InspectionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Inspection_Date");

                entity.Property(e => e.InspectionLocation)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("Inspection_Location");

                entity.Property(e => e.InspectorName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Inspector_Name");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.PassFail).HasColumnName("Pass_Fail");

                entity.Property(e => e.VehicleMaker).HasColumnName("Vehicle_Maker");

                entity.Property(e => e.VehicleModel)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle_Model");

                entity.Property(e => e.VehicleYear).HasColumnName("Vehicle_Year");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.VehicleMakerNavigation)
                    .WithMany(p => p.VehicleInspections)
                    .HasForeignKey(d => d.VehicleMaker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleInspection_VehicleMaker");
            });

            modelBuilder.Entity<VehicleMaker>(entity =>
            {
                entity.HasKey(e => e.MakerId);

                entity.ToTable("VehicleMaker");

                entity.Property(e => e.MakerId).HasColumnName("MakerID");

                entity.Property(e => e.Maker)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
