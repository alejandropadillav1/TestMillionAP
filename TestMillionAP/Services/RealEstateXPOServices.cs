using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.IO;
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
            var IdProperty = await CreatePropertyBuildingAsync(propertyModelView).ConfigureAwait(false);
            return await _uow.GetObjectByKeyAsync<Property>(IdProperty);
        }
        public async Task<int> AddImageProperty(ImagePropertyModelView imageProperty, CancellationToken token = default)
        {
            var property = await _uow.GetObjectByKeyAsync<Property>(imageProperty.IdProperty);
            if(property == null)
            {
                property = await CreateDefaultPropertyBuildingAsync();
            }
            var propertyImage = new PropertyImage(_uow);
            propertyImage.Enabled = true;
            propertyImage.FileName = imageProperty.File.FileName;
            propertyImage.Property = property;
            using(MemoryStream fileStream = new MemoryStream())
            {
                await imageProperty.File.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                propertyImage.File = fileStream.ToArray();
            }
            await _uow.CommitChangesAsync();
            return await Task.FromResult(propertyImage.Oid);
        }
        public async Task<int> CreatePropertyBuildingAsync(PropertyModelView propertyModelView, CancellationToken token = default)
        {
            if(propertyModelView.IdOwner == 0)
                throw new Exception("Id Owner should be greater than 0");
            var owner = await _uow.GetObjectByKeyAsync<Owner>(propertyModelView.IdOwner).ConfigureAwait(false);
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
        public async Task<int> CreatePropertyTraceAsync(PropertyTraceModelView propertyTraceModelView, CancellationToken token = default)
        {
            var property = await _uow.GetObjectByKeyAsync<Property>(propertyTraceModelView.IdProperty).ConfigureAwait(false);
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
        public async IAsyncEnumerable<OwnerModelView> GetAllOwnerModelViewAsync(CancellationToken token = default)
        {
            bool cancel = false;
            using var registration = token.Register(() => cancel = true);
            var listOwnerModelView = _uow.Query<Owner>().Select(x => new OwnerModelView { Address = x.Address, Birthday = x.Birthday, IdOwner = x.Oid, Photo = x.Photo, Name = x.Name }).ToListAsync();
            foreach(var ownerModelItem in await listOwnerModelView)
            {
                if(cancel)
                    break;
                yield return ownerModelItem;
            }
        }
        public async IAsyncEnumerable<PropertyModelView> GetAllPropertyModelViewAsync(CancellationToken token = default)
        {
            bool cancel = false;
            using var registration = token.Register(() => cancel = true);
            var listPropertyModelView = _uow.Query<Property>().Select(x => new PropertyModelView { Address = x.Address, CodeInternal = x.CodeInternal, IdOwner = x.Owner.Oid, IdProperty = x.Oid, Name = x.Name, Price = x.Price, Year = x.Year }).ToListAsync();
            foreach(var propertyItemView in await listPropertyModelView)
            {
                if(cancel)
                    break;
                yield return propertyItemView;
            }
        }
        public async IAsyncEnumerable<PropertyTraceModelView> GetAllPropertyTraceViewAsync(int IdPropertyModel, CancellationToken token = default)
        {
            bool cancel = false;
            using var registration = token.Register(() => cancel = true);
            var property = await _uow.GetObjectByKeyAsync<Property>(IdPropertyModel).ConfigureAwait(false);
            if(property == null)
                throw new Exception("The Id Property doesn't exist");
            var listPropertyTraceModel = _uow.Query<PropertyTrace>().Where(x => x.Property == property).Select(x => new PropertyTraceModelView { }).ToListAsync();
            foreach(var propertyTraceItem in await listPropertyTraceModel)
            {
                if(cancel)
                    break;
                yield return propertyTraceItem;
            }
        }
    }
}
