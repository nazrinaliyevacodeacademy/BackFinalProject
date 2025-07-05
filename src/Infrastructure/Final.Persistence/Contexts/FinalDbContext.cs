using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final.Persistence.Contexts;

    public  class FinalDbContext:DbContext
{
    public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.Entity<Department>().Property("Name");

        base.OnModelCreating(modelBuilder);

        // User – Prescription (Doctor / Patient)
        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Doctor)
            .WithMany(u => u.DoctorPrescriptions)
            .HasForeignKey(p => p.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Patient)
            .WithMany(u => u.PatientPrescriptions)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        // Many-to-Many: Prescription – Medicine
        modelBuilder.Entity<PrescriptionMedicine>()
            .HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });

        modelBuilder.Entity<PrescriptionMedicine>()
            .HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicines)
            .HasForeignKey(pm => pm.PrescriptionId);

        modelBuilder.Entity<PrescriptionMedicine>()
            .HasOne(pm => pm.Medicine)
            .WithMany(m => m.PrescriptionMedicines)
            .HasForeignKey(pm => pm.MedicineId);
    }

}
