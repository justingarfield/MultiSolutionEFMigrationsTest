using Microsoft.EntityFrameworkCore;
using MultiSolutionEfCoreMigrations.ModelProject;

namespace MultiSolutionEfCoreMigrations.DataProject
{
    
    public class SampleDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> contextOptions) : base(contextOptions) { }

    }

}
