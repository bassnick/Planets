// q: how to add external DLL to VS project?
// a: https://stackoverflow.com/questions/1178822/how-do-i-add-a-reference-to-a-net-core-class-library-from-a-net-framework-proj
using System;
using NUnit.Framework;
using PlanetsUtil;
namespace CRUD_UT_Tests
{
    [TestFixture]
    public class TestsProperties
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
        public void TestSuccessfullyCreatedProperty()
        {
            string errorMessage;
            PlanetProperty property = new PlanetProperty();
            property.Name = "Oxygen";
            bool exists = crudProperty.Create(property, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
        }

        [Test]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestNotUniqueName()
        {
            string errorMessage;
            PlanetProperty property1 = new PlanetProperty();
            property1.Name = "Oxygen";
            bool exists = crudProperty.Create(property1, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);

            PlanetProperty property2 = new PlanetProperty();
            property2.Name = "Oxygen";
            exists = crudProperty.Create(property2, out errorMessage);
            Assert.IsFalse(exists);
            Assert.IsNotNull(errorMessage);
        }
        [Test]
        public void TestNotFilledPropertyName()
        {
            string errorMessage;
            PlanetProperty property = new PlanetProperty();
            bool exists = crudProperty.Create(property, out errorMessage);
            Assert.IsFalse(exists); // here is Exception - correct instead of Assertion - todo fix it
            Assert.IsNotNull(errorMessage);
        }
        [Test]
        public void TestReadById()
        {
            string errorMessage;
            PlanetProperty property = new PlanetProperty();
            property.Name = "Oxygen";
            bool exists = crudProperty.Create(property, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
            
            List<PlanetProperty> all = crudProperty.ReadAll();
            PlanetProperty pp = all.Single(x => x.Name == property.Name);
            PlanetProperty pp2 = crudProperty.ReadById(pp.PropertyId);
            Assert.AreEqual(property, pp2);
        }
        [Test]
        public void TestReadByName()
        {
            string errorMessage;
            PlanetProperty property = new PlanetProperty();
            property.Name = "Oxygen";
            bool exists = crudProperty.Create(property, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);

            PlanetProperty pp = crudProperty.ReadByName(property.Name);
            Assert.AreEqual(property, pp);
        }
        // todo: test read by name by not existing Id
        // todo: test read by name by not existing Name

        [Test]
        public void TestSuccessfullUpdate()
        {
            string errorMessage;
            PlanetProperty property = new PlanetProperty();
            property.Name = "Oxygen";
            bool exists = crudProperty.Create(property, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
            PlanetProperty pp = crudProperty.ReadByName(property.Name);
            int propertyId = pp.PropertyId;
            
            property.Name = "Nitro";
            crudProperty.Update(property);
            PlanetProperty pp2 = crudProperty.ReadById(propertyId);
            
            Assert.AreEqual("Nitro", pp2.Name);
        }

        // todo: test not valid update - empty Name
        // todo: test not valid update - trying to update to not unique name

        [Test]
        public void TestSuccessfullDelete()
        {
            string errorMessage;
            PlanetProperty property = new PlanetProperty();
            property.Name = "Oxygen";
            bool exists = crudProperty.Create(property, out errorMessage);
            Assert.IsTrue(exists);
            Assert.IsNull(errorMessage);
            PlanetProperty pp = crudProperty.ReadByName(property.Name);
            int propertyId = pp.PropertyId;

            crudProperty.Delete(property);
            PlanetProperty pp2 = crudProperty.ReadByName(property.Name);
            Assert.IsNull(pp2);
        }
        // todo: test failed deleting when property does not exists
    }
} 
 