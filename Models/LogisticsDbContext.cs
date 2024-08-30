using Microsoft.EntityFrameworkCore;

public class LogisticsDbContext : DbContext {
    public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options) : base(options){}

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
    }
}