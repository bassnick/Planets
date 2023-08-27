using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsUtil
{
    public class CRUDPlanetPropertyOperations : ICRUD<PlanetProperty>
    {
        DBMappingContext context;

        public CRUDPlanetPropertyOperations(DBMappingContext context)
        {
            this.context = context;
        }
        public bool Create(PlanetProperty obj, out string errorMessage)
        {
            if (obj.Name == null || obj.Name.Length == 0)
            {
                errorMessage = "Planet Property must have filled the name.";
                return false;
            }
            if (context.PlanetPropertyModel.Any(p => p.Name == obj.Name))
            {
                errorMessage = "Planet Property already exists in this system.";
                return false;
            }
            else
            {
                context.PlanetPropertyModel.Add(obj);
                context.SaveChanges();
                errorMessage = null;
                return true;
            }
        }
        public void Update(PlanetProperty obj)
        {
            PlanetProperty planetProperty = context.PlanetPropertyModel.Find(obj.PropertyId);
            planetProperty = obj;
            context.SaveChanges();
        }

        public void Delete(PlanetProperty obj)
        {
            context.PlanetPropertyModel.Remove(obj);
            context.SaveChanges();
        }
        public List<PlanetProperty> ReadAll()
        {
            return context.PlanetPropertyModel.ToList<PlanetProperty>();
        }
        public PlanetProperty ReadById(int propertyId)
        {
            PlanetProperty property = context.PlanetPropertyModel.FirstOrDefault(x => x.PropertyId == propertyId);
            return property;
        }
        
        public PlanetProperty ReadByName(string propertyName)
        {
            PlanetProperty property = context.PlanetPropertyModel.FirstOrDefault(x => x.Name == propertyName);
            return property;
        }
        public bool Exists(PlanetProperty obj)
        {
            return context.PlanetPropertyModel.Any(e => e.PropertyId == obj.PropertyId);
        }


    }
}

