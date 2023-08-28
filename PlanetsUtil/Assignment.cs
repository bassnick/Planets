using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetsUtil
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int assignmentId { get; set; }
        public int planet { get; set; }
        public int planetProperty { get; set; }
        public string propertyValue { get; set; }
        internal Assignment(int planetId, int propertyid, string value) {
            this.planet = planetId;
            this.planetProperty = propertyid;
            this.propertyValue = value;
        }
    }
}
