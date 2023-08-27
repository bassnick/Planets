// q: how to add external DLL to VS project?
// a: https://stackoverflow.com/questions/1178822/how-do-i-add-a-reference-to-a-net-core-class-library-from-a-net-framework-proj
using System;
using System.Numerics;
using PlanetsUtil;
namespace CRUD_UT_Tests
{
    [TestFixture]
    public class TestsAssignments
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
        public void TestSuccessfullyCreatedAssignments()
        {
            string errorMessage;
            RockyPlanet planet = new RockyPlanet();
            planet.Name = "Mars";
            planet.Diameter = 125;
            bool tempExists = crudPlanet.Create(planet, out errorMessage);
            List<Planet> list = crudPlanet.ReadAll();
            int planetId = list.Single(x => x.Name == "Mars").PlanetId;

            PlanetProperty prop = new PlanetProperty();
            prop.Name = "Oxygen";
            bool tempExists2 = crudProperty.Create(prop, out errorMessage);
            List<PlanetProperty> list2 = crudProperty.ReadAll();
            int propertyId = list2.Single(x => x.Name == "Oxygen").PropertyId;


            Assignment assign = new Assignment();
            assign.planet = planetId;
            assign.planetProperty = propertyId;
            assign.propertyValue = "No";
            bool existsAssign = crudAssignments.Create(assign, out errorMessage);
            Assert.IsTrue(existsAssign);
            Assert.IsNull(errorMessage);
        }

        [Test]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestNotUnique()
        {
            string errorMessage;
            Assignment assign = new Assignment();
            assign.planet = 1;
            assign.planetProperty = 1;
            assign.propertyValue = "Test value";
            bool exists = crudAssignments.Create(assign, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);

            errorMessage = null;
            Assignment assign2 = new Assignment();
            assign2.planet = 1;
            assign2.planetProperty = 1;
            assign.propertyValue = "Test value 2"; 
            bool exists2 = crudAssignments.Create(assign2, out errorMessage);
            Assert.IsFalse(exists2);
            Assert.IsNotNull(errorMessage);
        }

        [Test]
        public void TestNotFilledColumns()
        {
            string errorMessage;
            Assignment assign = new Assignment();
            assign.planetProperty = 1;
            assign.propertyValue = "Test value"; 
            bool exists = crudAssignments.Create(assign, out errorMessage);
            Assert.IsFalse(exists, "Planet Id has to be filled.");
            Assert.IsNotNull(errorMessage);

            errorMessage = null;
            Assignment assign2 = new Assignment();
            assign2.planet = 1;
            assign2.propertyValue = "Test value";
            bool exists2 = crudAssignments.Create(assign, out errorMessage);
            Assert.IsFalse(exists2, "Planet Property Id has to be filled.");
            Assert.IsNotNull(errorMessage);
        }

        // todo: test of validation of columns
        // todo: test of validation of reading
        // todo: test read by name by not existing Id
        // todo: test read by name by not existing Name
        // todo: test not valid update - empty column planet
        // todo: test not valid update - empty column property
        // todo: test not valid update - trying to update to not unique combination of planet and property
        // todo: test of deleting
        // todo: test failed deleting when assigment does not exists

    }
} 
 