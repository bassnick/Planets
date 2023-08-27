using Microsoft.EntityFrameworkCore;

namespace PlanetsUtil
{
    public class DBMappingContext : DbContext
    {
        string dbName = "PlanetsDB.db";
        public DBMappingContext(string dbName = "PlanetsDB.db" )
        {
            this.dbName = dbName;
            this.Database.EnsureCreated();
        }
        public DbSet<PlanetProperty> PlanetPropertyModel { get; set; }
        public DbSet<Planet> PlanetModel { get; set; }
        public DbSet<RockyPlanet> RockyPlanetModel { get; set; }
        public DbSet<GasPlanet> GasPlanetModel { get; set; }
        public DbSet<Assignment> AssignmentModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dbName);
        }
        public void DropDB()
        {
            Database.EnsureDeleted( );
        }
    }
}
