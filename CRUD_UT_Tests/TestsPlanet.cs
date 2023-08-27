// q: how to add external DLL to VS project?
// a: https://stackoverflow.com/questions/1178822/how-do-i-add-a-reference-to-a-net-core-class-library-from-a-net-framework-proj
using System;
using PlanetsUtil;
namespace CRUD_UT_Tests
{
    [TestFixture]
    public class TestsPlanet
    {

        private string dbFileName = "TemporaryTests.db";
        private DBMappingContext dbMappingContext;
        private CRUDPlanetOperations crudPlanet;
        private CRUDPlanetPropertyOperations crudProperty;
        private CRUDAsssignmentsOperations crudAssignments;


        [SetUp]
        public void Setup()
        {
            this.dbMappingContext = new DBMappingContext(dbFileName);
            this.crudPlanet = new CRUDPlanetOperations(dbMappingContext);
            this.crudProperty = new CRUDPlanetPropertyOperations(dbMappingContext);
            this.crudAssignments = new CRUDAsssignmentsOperations(dbMappingContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbMappingContext.DropDB();
        }

        [Test]
        public void TestsPass()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void TestSuccessfullyCreatedRockyPlanet()
        {
            string errorMessage;
            RockyPlanet rockyPlanet = new RockyPlanet();
            rockyPlanet.Name = "Zelena Zeme";
            rockyPlanet.Diameter = 2 * 6378;
            bool exists = crudPlanet.Create(rockyPlanet, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
            bool existsInDb = crudPlanet.Exists(rockyPlanet);
            Assert.IsTrue(existsInDb);

        }
        [Test]
        public void TestSuccessfullyCreatedGasPlanet()
        {
            string errorMessage;
            GasPlanet gasPlanet = new GasPlanet();
            gasPlanet.Name = "Plynove svinstvo";
            gasPlanet.GasPressure = 500;
            bool exists = crudPlanet.Create(gasPlanet, out errorMessage);
            Assert.IsTrue(exists);
            bool existsInDb = crudPlanet.Exists(gasPlanet);
            Assert.IsTrue(existsInDb);
            Assert.IsNull(errorMessage);

        }
        [Test]
        public void TestNotUniqueName()
        {
            string errorMessage;
            RockyPlanet rockyPlanet = new RockyPlanet();
            rockyPlanet.Name = "Zelena Zeme";
            rockyPlanet.Diameter = 2 * 6378;
            bool exists = crudPlanet.Create(rockyPlanet, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
            bool existsInDb = crudPlanet.Exists(rockyPlanet);
            Assert.IsTrue(exists);

            errorMessage = null;
            RockyPlanet rockyPlanet2 = new RockyPlanet();
            rockyPlanet2.Name = "Zelena Zeme";
            rockyPlanet2.Diameter = 3 * 6378;
            bool exists2 = crudPlanet.Create(rockyPlanet2, out errorMessage);
            Assert.IsFalse(exists2); // todo : rather check exception
            Assert.IsNotNull(errorMessage);
            bool exists2InDb = crudPlanet.Exists(rockyPlanet2); // todo: Is exception?
            Assert.IsFalse(exists2InDb); // todo : rather check exception
        }

        [Test]
        public void TestNotFilledRockyPlanetName()
        {
            string errorMessage;
            RockyPlanet rockyPlanet = new RockyPlanet();
            rockyPlanet.Diameter = 2 * 6378;
            bool exists = crudPlanet.Create(rockyPlanet, out errorMessage);
            Assert.IsFalse(exists); // here is Exception - correct instead of Assertion - todo fix it
            Assert.IsNotNull(errorMessage);
            bool existsInDb = crudPlanet.Exists(rockyPlanet);
            Assert.IsFalse(exists); // here is Exception - correct instead of Assertion - todo fix it
        }
        [Test]
        public void TestNotFilledDiamater()
        {
            string errorMessage;
            RockyPlanet rockyPlanet = new RockyPlanet();
            rockyPlanet.Name = "Zelena Zeme";
            bool exists = crudPlanet.Create(rockyPlanet, out errorMessage);
            Assert.IsFalse(exists);
            Assert.IsNotNull(errorMessage);
            bool existsInDb = crudPlanet.Exists(rockyPlanet);
            Assert.IsFalse(existsInDb);
        }

        [Test]
        public void TestNotFilledGasPlanetName()
        {
            string errorMessage;
            GasPlanet gasPlanet = new GasPlanet();
            gasPlanet.GasPressure = 100;
            bool exists = crudPlanet.Create(gasPlanet, out errorMessage);
            Assert.IsFalse(exists); // here is Exception - correct instead of Assertion - todo fix it
            Assert.IsNotNull(errorMessage);
            bool existsInDb = crudPlanet.Exists(gasPlanet);
            Assert.IsFalse(exists); // here is Exception - correct instead of Assertion - todo fix it
        }
        [Test]
        public void TestNotFilledGasPressure()
        {
            string errorMessage;
            GasPlanet gasPlanet = new GasPlanet();
            gasPlanet.Name = "Plynove teleso";
            bool exists = crudPlanet.Create(gasPlanet, out errorMessage);
            Assert.IsFalse(exists);
            Assert.IsNotNull(errorMessage);
            bool existsInDb = crudPlanet.Exists(gasPlanet);
            Assert.IsFalse(existsInDb);
        }
        [Test]
        public void TestReadById()
        {
            string errorMessage;
            GasPlanet gasPlanet = new GasPlanet();
            gasPlanet.Name = "Plynove teleso";
            gasPlanet.GasPressure = 100;
            bool exists = crudPlanet.Create(gasPlanet, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
            List<Planet> all = crudPlanet.ReadAll();
            Planet p = all.Single(x => x.Name == "Plynove teleso");
            Planet p2 = crudPlanet.ReadById(p.PlanetId);
            Assert.AreEqual(gasPlanet, p2);
        }
        [Test]
        public void TestReadByName()
        {
            string errorMessage;
            GasPlanet gasPlanet = new GasPlanet();
            gasPlanet.Name = "Plynove teleso";
            gasPlanet.GasPressure = 100;
            bool exists = crudPlanet.Create(gasPlanet, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
            Planet p = crudPlanet.ReadByName(gasPlanet.Name);
            Assert.AreEqual(gasPlanet, p);
        }
        // todo: test read by name by not existing Id
        // todo: test read by name by not existing Name
        
        [Test]
        public void TestSuccessfullUpdate() {
            string errorMessage;
            GasPlanet gasPlanet = new GasPlanet();
            gasPlanet.Name = "Plynove teleso";
            gasPlanet.GasPressure = 100;
            bool exists = crudPlanet.Create(gasPlanet, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);

            gasPlanet.GasPressure = 200;
            crudPlanet.Update(gasPlanet);
            Planet p = crudPlanet.ReadByName(gasPlanet.Name);

            Assert.AreEqual(200, ((GasPlanet)p).GasPressure);
        }
        // todo: test not valid update - empty Name
        // todo: test not valid update - empty GasPreasure, Diameter
        // todo: test not valid update - trying to update to not unique name

        [Test]
        public void TestSuccessfullDelete()
        {
            string errorMessage;
            GasPlanet gasPlanet = new GasPlanet();
            gasPlanet.Name = "Plynove teleso";
            gasPlanet.GasPressure = 100;
            bool exists = crudPlanet.Create(gasPlanet, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);

            crudPlanet.Delete(gasPlanet);
            Planet p = crudPlanet.ReadByName(gasPlanet.Name);

            Assert.IsNull(p);
        }
        // todo: test failed deleting when planet does not exists
    }
} 