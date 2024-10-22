using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewEmployeeManagement.Models;

namespace NewEmployeeManagement.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<EmployeeModel> Employees { get; set; }

    public DbSet<DepartmentModel> Departments { get; set; }

    public DbSet<DesignationModel> Designations { get; set; }

    public DbSet<LeaveTypeModel> LeaveTypes { get; set; }

    public DbSet<LeaveDurationModel> LeaveDurations { get; set; }

    public DbSet<LeaveApplicationModel> LeaveApplications { get; set; }

    public DbSet<LeaveStatusModel> LeaveStatus { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach(var relationship in builder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

       


        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}
