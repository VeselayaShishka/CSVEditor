namespace CSVEditor.Data;

using Models;
using Microsoft.EntityFrameworkCore;

public class CSVDbContext : DbContext
{
    public CSVDbContext(
        DbContextOptions<CSVDbContext> dbContext) : base(dbContext) { }
    
    public DbSet<UserRecord> UserRecords => Set<UserRecord>();
}