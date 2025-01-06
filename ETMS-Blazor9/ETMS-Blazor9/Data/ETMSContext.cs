using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ETMS.Data;
using ETMS_Blazor9.Components.shared;

    public class ETMSContext : DbContext
    {
        public ETMSContext (DbContextOptions<ETMSContext> options)
            : base(options)
        {
        }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(p => p.EmployeeID)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Course>()
          .Property(p => p.CourseID)
          .ValueGeneratedOnAdd();

        modelBuilder.Entity<EmployeeCourse>()
          .Property(p => p.EmployeeCourseID)
          .ValueGeneratedOnAdd();


        //modelBuilder.Entity<Employee>()
        //    .Property(e => e.RowId).HasDefaultValueSql("NEWID()");

        //modelBuilder.Entity<Course>()
        //    .Property(e => e.RowId).HasDefaultValueSql("NEWID()");

    }

    public DbSet<ETMS.Data.Employee> Employee { get; set; } = default!;

        public DbSet<ETMS.Data.Course> Course { get; set; } = default!;

       public DbSet<ETMS.Data.EmployeeCourse> EmployeeCourse { get; set; } = default!;
}
