using EmplyoeeManagementMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmplyoeeManagementMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Emplyoee> Emplyoees { get; set; }

    }
}
