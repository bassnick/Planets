using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsUtil
{
    public class Facade
    {
        string dbName { get; }

        public Facade(string dbName) 
        { 
            this.dbName = dbName;
        }

        public void CreatePlanet(Planet planet) 
        { 
        }
        public void CreateProperty(PlanetProperty prop)
        {

        }
        public void CreatePropertyValue(Assignment assign)
        { 
        }
        public void CreatePropertyValue(Planet planet, PlanetProperty property, string value)
        {
        }
        public void UpdatePlanet(Planet planet)
        {
        }
        public void UpdateProperty(PlanetProperty prop)
        {
        }
        public void UpdatePropertyValue(Assignment assign)
        {
        }
        public void DeletePlanet(Planet planet)
        {
        }
        public void DeleteProperty(PlanetProperty prop)
        {
        }
        public void DeletePropertyValue(Assignment assign)
        {
        }
        public Planet GetPlanetById(int id)
        {
            return null;
        }
        public PlanetProperty GetPropertyById(int id)
        {
            return null;
        }
        public string GetPropertyValueById(int id)
        {
            return null;
        }
        public List<Planet> GetPlanetsByProperty()
        {
            return null;
        }
        public List<PlanetProperty> GetPropertiesByPlanet()
        {
            return null;
        }
        public List<string> GetPropertyValuePlanetAndProperty()
        {
            return null;
        }
        public List<Planet> GetAllPlanets()
        {
            return null;
        }
        public List<PlanetProperty> GetAllProperties()
        {
            return null;
        }
        public List<Assignment> GetAllAssignments()
        {
            return null;
        }
        public List<Planet> GetPlanetsWithoutProperties()
        {
            return null;
        }
        public List<PlanetProperty> GetPropertiesWithoutPlanets()
        {
            return null;
        }


    }
}
