using System.ComponentModel.DataAnnotations;

namespace PlanetsUtil
{
    public class PlanetProperty
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }
    }
}
