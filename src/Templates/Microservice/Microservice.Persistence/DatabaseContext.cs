namespace Microservice.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) 
        : base(options) { }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly (AssemblyReference.Assembly);
}