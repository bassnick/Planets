using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace PlanetsUtil
{
    public class Planet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PlanetId { get; set; }
        // q: how to set that PlanetId as autoincrement key?
        public string Name { get; set; }
        /*
        public int Size { get; set; }
        public double Mass { get; set; }
        public double Diameter { get; set; }
        public double Density { get; set; }
        public double Gravity { get; set; }
        public double RotationPeriod { get; set; }
        public double LengthOfDay { get; set; }
        public double DistanceFromSun { get; set; }
        public double OrbitalPeriod { get; set; }
        public double OrbitalVelocity { get; set; }
        public double MeanTemperature { get; set; }
        public double NumberOfMoons { get; set; }
        public bool RingSystem { get; set; }
        */
        public ICollection<PlanetProperty> Properties { get; set; }

        public Planet() { 
        }
    }

    public class RockyPlanet : Planet
    {   
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int PlanetId { get; set; }
        
        public double Diameter { get; set; }

    }

    public class GasPlanet : Planet
    {
        
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int PlanetId { get; set; } 
        
        public double GasPressure { get; set; }
    }
}
