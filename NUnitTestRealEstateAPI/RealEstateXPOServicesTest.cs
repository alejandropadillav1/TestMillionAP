using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestMillionAP.ModelView;
using TestMillionAP.Services;
namespace NUnitTestRealEstateAPI
{
    [TestFixture]
    public class BaseTests
    {
        protected UnitOfWork _uow;
        protected IDataLayer dataLayer;
        protected IDisposable[] disposablesOnDisconect;
        protected virtual IDataStore CreateProvider()
        { return new InMemoryDataStore(AutoCreateOption.DatabaseAndSchema); }
        [Test]
        public async Task CreateNewBuildingPropertyTest()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var property = new PropertyModelView { Address = "Addresstest", CodeInternal = "Code", IdOwner = 1, IdProperty = 1, Name = "NameTest", Price = 2540, Year = 2015 };
            var result = await realEstate.CreatePropertyBuildingAsync(property);
            Assert.AreEqual(result, 1);
        }
        [Test]
        public void CreateNewBuildingPropertyTestWithoutOwnerId()
        {
            RealEstateXPOServices realEstate = new RealEstateXPOServices(_uow);
            var property = new PropertyModelView { Address = "Addresstest", CodeInternal = "Code", IdOwner = 0, IdProperty = 1, Name = "NameTest", Price = 2540, Year = 2015 };
            // var result = await realEstate.CreatePropertyBuildingAsync(property);
            Assert.ThrowsAsync<Exception>(async () => await realEstate.CreatePropertyBuildingAsync(property));
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
            if(disposablesOnDisconect != null)
            {
                foreach(IDisposable disp in disposablesOnDisconect)
                {
                    disp.Dispose();
                }
            }
        }
    }
}
