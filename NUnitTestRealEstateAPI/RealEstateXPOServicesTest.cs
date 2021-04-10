using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestMillionAP.ModelView;
using TestMillionAP.Services;
namespace NUnitTestRealEstateAPI
{
    /// <summary>
    ///   Create a Test Fixture Class, and construct required testing method, it could implement with the Services, Controllers by the way, for this test I will implement as a services.
    /// </summary>
    [TestFixture]
    public class BaseTests
    {
        protected UnitOfWork _uow;
        protected IDataLayer dataLayer;
        protected IDisposable[] disposableOnDisconnect;
        protected virtual IDataStore CreateProvider()
        { return new InMemoryDataStore(AutoCreateOption.DatabaseAndSchema); }
        [Test]
        public async Task AddImagePropertyTest()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var fileStream = System.IO.File.OpenRead(@"TestImage\descargar.png");
            // var file = System.IO.File.ReadAllBytes(@"TestImage\descargar.png");
            var property = new ImagePropertyModelView { IdProperty = 1, File = new FormFile(fileStream, 0, fileStream.Length, "descargar", "descargar.png") };
            var result = await realEstate.AddImageProperty(property);
            fileStream.Close();
            Assert.IsTrue(result > 0);
        }
        /// <summary>
        ///   This test method must return an Id of property building after the saving changes.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreateNewBuildingPropertyTest()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var property = new PropertyModelView { Address = "AddressTest", CodeInternal = "Code", IdOwner = 1, IdProperty = 1, Name = "NameTest", Price = 2540, Year = 2015 };
            var result = await realEstate.CreatePropertyBuildingAsync(property);
            Assert.AreEqual(result, 1);
        }
        /// <summary>
        ///   This test method must throw an exception if the Id Owner is less  than 0, only for create unknown
        /// </summary>
        [Test]
        public async Task CreateNewBuildingPropertyTestCreateDefaultOwner()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var property = new PropertyModelView { Address = "AddressTest", CodeInternal = "Code", IdOwner = -1, IdProperty = 1, Name = "NameTest", Price = 2540, Year = 2015 };
            var result = await realEstate.CreatePropertyBuildingAsync(property);
            Assert.IsTrue(result > 0);
        }
        /// <summary>
        ///   This test method must throw an exception if the Id Owner  equal than 0.
        /// </summary>
        [Test]
        public void CreateNewBuildingPropertyTestWithoutOwnerId()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var property = new PropertyModelView { Address = "AddressTest", CodeInternal = "Code", IdOwner = 0, IdProperty = 1, Name = "NameTest", Price = 2540, Year = 2015 };
            Assert.ThrowsAsync<Exception>(async () => await realEstate.CreatePropertyBuildingAsync(property));
        }
        /// <summary>
        ///   This test method is for create a new Property Trace
        /// </summary>
        [Test]
        public async Task CreateNewPropertyTraceTestDefault()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var property = new PropertyTraceModelView { DateSale = DateTime.Now, IdProperty = -1, Name = "Test Name", Tax = 20, Value = 20000 };
            var result = await realEstate.CreatePropertyTraceAsync(property);
            Assert.IsTrue(result > 0);
        }
        /// <summary>
        ///   This test method is for create a new Property Trace
        /// </summary>
        [Test]
        public void GetPropertyTraceModelFilter()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var exp = realEstate.GetAllPropertyTraceViewAsync(0);
            Assert.IsTrue(exp.GetAsyncEnumerator().Current == null);
        }
        [SetUp]
        public virtual void SetUp()
        {
            IDataStore ds = new InMemoryDataStore();
            ((IDataStoreForTests)ds).ClearDatabase();
            dataLayer = new SimpleDataLayer(ds);
            _uow = new UnitOfWork(dataLayer);
        }
        [TearDown]
        public virtual void TearDown()
        {
            dataLayer.Dispose();
            if(disposableOnDisconnect != null)
            {
                foreach(IDisposable disp in disposableOnDisconnect)
                {
                    disp.Dispose();
                }
            }
        }
    }
}
