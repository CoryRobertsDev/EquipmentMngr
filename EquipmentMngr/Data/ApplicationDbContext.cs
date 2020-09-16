using EquipmentMngr.Data.Entities;
using EquipmentMngr.Helpers;
using EquipmentMngr.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace EquipmentMngr.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;

        [Log]
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService)
            : base(options)
        {
            this._currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

  

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ViewAssignmentsDetail> AssignmentDetails { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Repair> Repairs { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSave()
        {
            var currentTime = DateTimeOffset.UtcNow;
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is Entity))
            {
                var entidad = item.Entity as Entity;
                entidad.CreatedDate = currentTime;
                entidad.CreatedByUser = _currentUserService.GetCurrentUsername();
                entidad.ModifiedDate = currentTime;
                entidad.ModifiedByUser = _currentUserService.GetCurrentUsername();
            }

            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified && e.Entity is Entity))
            {
                var entidad = item.Entity as Entity;
                entidad.ModifiedDate = currentTime;
                entidad.ModifiedByUser = _currentUserService.GetCurrentUsername();
                item.Property(nameof(entidad.CreatedDate)).IsModified = false;
                item.Property(nameof(entidad.CreatedByUser)).IsModified = false;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ColleagueNames>(entity =>
              {
                  entity.HasNoKey();

                  entity.ToView("ColleagueName");

                  entity.Property(e => e.FirstName).IsUnicode(false);

                  entity.Property(e => e.LastName).IsUnicode(false);
              });

            modelBuilder.Entity<Assignment>(entity =>
            {

                entity.HasIndex(e => e.ColleagueId);

                entity.HasIndex(e => e.DepartmentId);

                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.LocationId);

            });
            modelBuilder.Entity<Equipment>(entity =>
          {
              modelBuilder.Entity<Equipment>()
                  .Property(e => e.StatusId)
                  .HasDefaultValue(4);

              entity.HasIndex(e => e.EquipmentTypeId);

              entity.HasIndex(e => e.ManufacturerId);

              entity.HasIndex(e => e.VendorId);

              entity.HasIndex(e => e.StatusId);


          });

            modelBuilder.Entity<ViewAssignmentsDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_AssignmentsDetail");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });
        }

    }

}