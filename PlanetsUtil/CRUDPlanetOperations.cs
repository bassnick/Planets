using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsUtil
{
    public class CRUDPlanetOperations: ICRUD<Planet>
    {
        DBMappingContext context;

        public CRUDPlanetOperations(DBMappingContext context)
        {
            this.context = context;
        }

        public bool Create(Planet obj, out string errorMessage)
        {
            if (obj.Name == null || obj.Name.Length == 0) {
                errorMessage = "Planet must have filled the name.";
                return false;
            }
            else if (context.PlanetModel.Any(p => p.Name == obj.Name))
            {
                errorMessage = "Planet with this name already exists in this system.";
                return false;
            }
            else if (obj is RockyPlanet && (((RockyPlanet)obj).Diameter == null || ((RockyPlanet)obj).Diameter <= 0.0))
            {
                errorMessage = "Rocky planet must have inforamtion of diameter.";
                return false;
            }
            else if (obj is GasPlanet && (((GasPlanet)obj).GasPressure == null || ((GasPlanet)obj).GasPressure <= 0.0))
            {
                errorMessage = "Gas planet must have information of gas pressure.";
                return false;
            }
            else
            {

                context.PlanetModel.Add(obj);
                context.SaveChanges();
                errorMessage = null;
                return true;
            }
        }
        
        public void Update(Planet obj)
        {
            Planet planet = context.PlanetModel.Find(obj.PlanetId);
            planet = obj;
            context.SaveChanges();
            
        }
        public void Delete(Planet obj)
        {
            context.PlanetModel.Remove(obj);
            context.SaveChanges();
        }
        public List<Planet> ReadAll()
        {
            return context.PlanetModel.ToList<Planet>(); 
        }
        public Planet ReadById(int planetId)
        {
            Planet planet =context.PlanetModel.FirstOrDefault(x => x.PlanetId == planetId);
            return planet;
        }
        public Planet ReadByName(string planetName)
        {
            Planet planet = context.PlanetModel.FirstOrDefault(x => x.Name == planetName);
            return planet;
        }

        public bool Exists(Planet obj)
        {
            return context.PlanetModel.Any(e => e.PlanetId == obj.PlanetId);
        }



     }
}
