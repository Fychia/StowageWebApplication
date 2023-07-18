using Microsoft.EntityFrameworkCore;
using StowageApplication.Models;

namespace StowageApplication.Data
{
    public class FileStowageContext : DbContext
    {
        public FileStowageContext(DbContextOptions<FileStowageContext> options) : base (options) { }

        public DbSet<FileStowage> FileStowage { get; set; }



    }
}
