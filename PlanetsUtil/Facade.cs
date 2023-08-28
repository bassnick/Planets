using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlanetsUtil
{
    public class Facade
    {
        private DBMappingContext dbMappingContext;
        private CRUDPlanetOperations crudPlanet;
        private CRUDPlanetPropertyOperations crudProperty;
        private CRUDAsssignmentsOperations crudAssignments;
        private string errorMessage;

        public Facade(string dbName = "PlanetsDB.db") { 
            this.dbMappingContext = new DBMappingContext(dbName);
            this.crudPlanet = new CRUDPlanetOperations(dbMappingContext);
            this.crudProperty = new CRUDPlanetPropertyOperations(dbMappingContext);
            this.crudAssignments = new CRUDAsssignmentsOperations(dbMappingContext);
        }

        public void CreatePlanet(Planet planet) 
        {
            bool exists = crudPlanet.Create(planet, out errorMessage);
        }
        public void CreateProperty(PlanetProperty prop)
        {
            bool exists = crudProperty.Create(prop, out errorMessage);

        }
        public void CreatePropertyValue(Assignment assign)
        { 
            bool exists = crudAssignments.Create(assign, out errorMessage);
        }
        public void CreatePropertyValue(Planet planet, PlanetProperty property, string value)
        {
            Assignment assign = new Assignment(planet.PlanetId, property.PropertyId, value);
            bool exists = crudAssignments.Create(assign, out errorMessage);
        }
        public void UpdatePlanet(Planet planet)
        {
            crudPlanet.Update(planet);
        }
        public void UpdateProperty(PlanetProperty prop)
        {
            crudProperty.Update(prop);
        }
        public void UpdatePropertyValue(Assignment assign)
        {
            crudAssignments.Update(assign);
        }
        public void DeletePlanet(Planet planet)
        {
            crudPlanet.Delete(planet);
        }
        public void DeleteProperty(PlanetProperty prop)
        {
            crudProperty.Delete(prop);
        }
        public void DeletePropertyValue(Assignment assign)
        {
            crudAssignments.Delete(assign);
        }
        public Planet GetPlanetById(int id)
        {
            return crudPlanet.ReadById(id);
        }
        public PlanetProperty GetPropertyById(int id)
        {
            return crudProperty.ReadById(id);
        }
        public string GetPropertyValueById(int id)
        {
            return crudAssignments.ReadById(id).propertyValue;
        }
        public List<Planet> GetPlanetsByProperty(PlanetProperty prop)
        {
            List<Planet> all = crudPlanet.ReadAll();
            
            int propId = prop.PropertyId;
            List<Assignment> assignments = crudAssignments.ReadAll();
            List<int> planetsId = assignments.Where(x => x.planetProperty == propId).Select(x => x.planet).ToList();
            List<Planet> planets = all.Where(x => planetsId.Contains(x.PlanetId)).ToList();
            return planets;                   
        }
        public List<PlanetProperty> GetPropertiesByPlanet(Planet planet)
        {
            List<PlanetProperty> all = crudProperty.ReadAll();
            int planetId = planet.PlanetId;
            List<Assignment> assignments = crudAssignments.ReadAll();
            List<int> propertiesId = assignments.Where(x => x.planet == planetId).Select(x => x.planetProperty).ToList();
            List<PlanetProperty> properties = all.Where(x => propertiesId.Contains(x.PropertyId)).ToList();
            return properties;
        }
        public string GetPropertyValuePlanetAndProperty(Planet planet, PlanetProperty property)
        {
            List<Assignment> assignments = crudAssignments.ReadAll();
            string result = assignments.Find(x => x.planet == planet.PlanetId && x.planetProperty == property.PropertyId).propertyValue;
            return result;
        }
        public List<Planet> GetAllPlanets()
        {
            List<Planet> all = crudPlanet.ReadAll();
            return all;
        }
        public List<PlanetProperty> GetAllProperties()
        {
            List<PlanetProperty> all = crudProperty.ReadAll();
            return all;
        }
        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> all = crudAssignments.ReadAll();
            return all;
        }
        public List<Planet> GetPlanetsWithoutProperties()
        {
            List<Planet> all = crudPlanet.ReadAll();
            List<Assignment> assignments = crudAssignments.ReadAll();
            List<int> planetsId = assignments.Select(x => x.planet).ToList();
            List<Planet> planets = all.Where(x => !planetsId.Contains(x.PlanetId)).ToList();
            return planets;

        }
        public List<PlanetProperty> GetPropertiesWithoutPlanets()
        {
            List<PlanetProperty> all = crudProperty.ReadAll();
            List<Assignment> assignments = crudAssignments.ReadAll();
            List<int> propertiesId = assignments.Select(x => x.planetProperty).ToList();
            List<PlanetProperty> properties = all.Where(x => !propertiesId.Contains(x.PropertyId)).ToList();
            return properties;
        }
        /*
        public List<Planet> GetAll() { 
          // todo: will be good to have a method that returns all planets with their properties and values 
            (todo: Add to class Planet a dictionary with key: property name ad value: property value)
        }
        */
        public void dropDb()
        {
            dbMappingContext.DropDB();
        }
    }
}
