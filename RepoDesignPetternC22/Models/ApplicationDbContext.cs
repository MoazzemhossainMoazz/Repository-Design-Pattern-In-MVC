using Microsoft.EntityFrameworkCore;

namespace RepoDesignPetternC22.Models
{
    public partial class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
