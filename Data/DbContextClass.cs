using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilesApp.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions options) : base(options)
        {

        }
        public DbSet<FileData> FileData { get; set; }
    }
}
