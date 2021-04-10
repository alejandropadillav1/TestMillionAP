using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestMillionAP.Interface;
using TestMillionAP.Model;
using TestMillionAP.ModelView;
namespace TestMillionAP.Services
{
    /// <summary>
    ///   Model Class for XPO (ORM), see the benchmarking between EF - EF Core - XPO - https://community.devexpress.com/blogs/xpo/archive/2018/07/17/xpo-a-simple-benchmark-against-ef-6-and-ef-core-update.aspx  The XPO ORM doesn't required to declare NotifyPropertyChanged event because of XPO ORM already pre built using with SetPropertyValue
    ///   automatically.
    /// </summary>
    public class RealEstateXPOServices : IRealEstateServices
    {
        private readonly UnitOfWork _uow;
        public RealEstateXPOServices(UnitOfWork uow) { _uow = uow; }
        /// <summary>
        ///   SOLID PRinciples, Single responsibilities.
        /// </summary>
        /// <returns></returns>
        private async Task<Property> CreateDefaultPropertyBuildingAsync()
        {
            var propertyModelView = new PropertyModelView { Address = "Unknown Address", CodeInternal = "Code Internal Unknown", Name = "Unknown Name", Price = 0, Year = DateTime.Now.Year, IdOwner = -1, };
            var IdProperty = await CreatePropertyBuildingAsync(propertyModelView);
            return await _uow.GetObjectByKeyAsync<Property>(IdProperty);
        }
        public Task<int> AddImageProperty(ImagePropertyModelView imageProperty, CancellationTokenSource token = null)
        { throw new NotImplementedException(); }
        public async Task<int> CreatePropertyBuildingAsync(PropertyModelView propertyModelView, CancellationTokenSource token = null)
        {
            if(propertyModelView.IdOwner == 0)
                throw new Exception("Id Owner should be greater than 0");
            var owner = await _uow.GetObjectByKeyAsync<Owner>(propertyModelView.IdOwner);
            if(owner == null)
            {
                owner = new Owner(_uow);
                owner.Address = "Unknown address";
                owner.Birthday = DateTime.Now;
                owner.Name = "Unknown name";
            }
            var propertyBuilding = new Property(_uow);
            propertyBuilding.Name = propertyModelView.Name;
            propertyBuilding.Address = propertyModelView.Address;
            propertyBuilding.Owner = owner;
            propertyBuilding.Price = propertyModelView.Price;
            propertyBuilding.Year = propertyModelView.Year;
            propertyBuilding.CodeInternal = propertyModelView.CodeInternal;
            await _uow.CommitChangesAsync();
            return await Task.FromResult(propertyBuilding.Oid);
        }
        public async Task<int> CreatePropertyTraceAsync(PropertyTraceModelView propertyTraceModelView, CancellationTokenSource token = null)
        {
            var property = await _uow.GetObjectByKeyAsync<Property>(propertyTraceModelView.IdProperty);
            if(property == null)
            {
                property = await CreateDefaultPropertyBuildingAsync();
            }
            var propertyTrace = new PropertyTrace(_uow);
            propertyTrace.Property = property;
            propertyTrace.Name = propertyTraceModelView.Name;
            propertyTrace.Tax = propertyTraceModelView.Tax;
            propertyTrace.Value = propertyTraceModelView.Value;
            propertyTrace.DateSale = propertyTraceModelView.DateSale;
            await _uow.CommitTransactionAsync();
            return await Task.FromResult(propertyTrace.Oid);
        }
        public async IAsyncEnumerable<OwnerModelView> GetAllOwnerModelViewAsync(CancellationTokenSource token = null)
        {
            var listOwnerModelView = _uow.Query<Owner>().Select(x => new OwnerModelView { Address = x.Address, Birthday = x.Birthday, IdOwner = x.Oid, Photo = x.Photo, Name = x.Name }).ToListAsync();
            foreach(var ownerModelItem in await listOwnerModelView)
            {
                yield return ownerModelItem;
            }
        }
        public async IAsyncEnumerable<PropertyModelView> GetAllPropertyModelViewAsync(CancellationTokenSource token = null)
        {
            var listPropertyModelView = _uow.Query<Property>().Select(x => new PropertyModelView { Address = x.Address, CodeInternal = x.CodeInternal, IdOwner = x.Owner.Oid, IdProperty = x.Oid, Name = x.Name, Price = x.Price, Year = x.Year }).ToListAsync();
            foreach(var propertyItemView in await listPropertyModelView)
            {
                yield return propertyItemView;
            }
        }
    }
}
