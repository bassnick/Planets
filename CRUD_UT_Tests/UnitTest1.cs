// q: how to add external DLL to VS project?
// a: https://stackoverflow.com/questions/1178822/how-do-i-add-a-reference-to-a-net-core-class-library-from-a-net-framework-proj
/*using System;
using PlanetsUtil;
namespace CRUD_UT_Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DbToolAPI dbToolAPI = new DbToolAPI("TestT.db");
            dbToolAPI.NewDB();
        }

        [Test]
        public void TestsPass()
        {
            Assert.AreEqual(1, 1);
        }

        public void TestSuccessfullyCreatedRockyPlanet()
        {
            CRUDPlanetOperations crudPlanet = new CRUDPlanetOperations();
            RockyPlanet rockyPlanet = new RockyPlanet();
            rockyPlanet.Name = "Zelena Zeme";
            rockyPlanet.Diameter = 2 * 6378;
            crudPlanet.Create(rockyPlanet);
            bool exists = crudPlanet.Exists(rockyPlanet);
            Assert.IsTrue(exists);
        }


        [Test]
        public void TestSuccessfullyCreatedRockyPlanet() 
        {
            CRUDPlanetOperations crudPlanet = new CRUDPlanetOperations();
            RockyPlanet rockyPlanet = new RockyPlanet();
            rockyPlanet.Name = "Zelena Zeme";
            rockyPlanet.Diameter = 2 * 6378;
            crudPlanet.Create(rockyPlanet);
            bool exists = crudPlanet.Exists(rockyPlanet);
            Assert.IsTrue(exists);
        }

        [Test]
        public void TestCopyOfConsole()
        {
            CRUDPlanetPropertyOperations crudPlanetPropertyOperations = new CRUDPlanetPropertyOperations();
            PlanetProperty planetProperty = new PlanetProperty();
            planetProperty.Name = "Oxygen";
            planetProperty.Value = "";
            crudPlanetPropertyOperations.Create(planetProperty);
            Console.WriteLine("PlanetProperty created");

            CRUDPlanetOperations crudPlanet = new CRUDPlanetOperations();
            RockyPlanet rockyPlanet = new RockyPlanet();
            rockyPlanet.Name = "Zelena Zeme";
            rockyPlanet.Diameter = 2 * 6378;

            GasPlanet gasPlanet3 = new GasPlanet();
            gasPlanet3.Name = "Plynove svinstvo";
            gasPlanet3.GasPressure = 500;


            crudPlanet.Create(rockyPlanet);
            Console.WriteLine("1st Planet created");

            crudPlanet.Create(gasPlanet3);
            Console.WriteLine("2nd Planet created");

            CRUDAsssignmentsOperations crudAsssignmentsOperations = new CRUDAsssignmentsOperations();
            crudAsssignmentsOperations.Create(rockyPlanet, planetProperty, "Yes");
            Console.WriteLine("1st association created");
            crudAsssignmentsOperations.Create(gasPlanet3, planetProperty, "No");
            Console.WriteLine("2nd association created");
            Assert.Pass();
        }
    }
}*/