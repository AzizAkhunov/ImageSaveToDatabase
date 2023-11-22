using ImageSaveToDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageSaveToDatabase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<ProfileTeacher> Teachers { get; set; }
    }
}
