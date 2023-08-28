using Microsoft.EntityFrameworkCore;

namespace PlanetsUtil
{
    internal class DBMappingContext : DbContext
    {
        internal string dbName = "PlanetsDB.db";
        internal DBMappingContext(string dbName = "PlanetsDB.db" )
        {
            this.dbName = dbName;
            this.Database.EnsureCreated();
        }
        internal DbSet<PlanetProperty> PlanetPropertyModel { get; set; }
        internal DbSet<Planet> PlanetModel { get; set; }
        internal DbSet<RockyPlanet> RockyPlanetModel { get; set; }
        internal DbSet<GasPlanet> GasPlanetModel { get; set; }
        internal DbSet<Assignment> AssignmentModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dbName);
        }
        internal void DropDB()
        {
            Database.EnsureDeleted( );
        }
    }
}
