using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestMillionAP.Interface;
using TestMillionAP.ModelView;
namespace TestMillionAP.Services
{
    /// <summary>
    ///   In a next sprint, it should implements with a Redis Cache Server
    /// </summary>
    public class RealEstateRedisCacheServices : IRealEstateServices
    {
        public Task<int> AddImageProperty(ImagePropertyModelView imageProperty, CancellationToken token = default)
        { throw new NotImplementedException(); }
        public Task<int> CreatePropertyBuildingAsync(PropertyModelView propertyModelView, CancellationToken token = default)
        { throw new NotImplementedException(); }
        public Task<int> CreatePropertyTraceAsync(PropertyTraceModelView propertyTraceModelView, CancellationToken token = default)
        { throw new NotImplementedException(); }
        public IAsyncEnumerable<ImagePropertyModelView> GetAllImagePropertyAsync(CancellationToken token = default)
        { throw new NotImplementedException(); }
        public IAsyncEnumerable<OwnerModelView> GetAllOwnerModelViewAsync(CancellationToken token = default)
        { throw new NotImplementedException(); }
        public IAsyncEnumerable<PropertyModelView> GetAllPropertyModelViewAsync(CancellationToken token = default)
        { throw new NotImplementedException(); }
        public IAsyncEnumerable<PropertyTraceModelView> GetAllPropertyTraceViewAsync(int IdPropertyModel, CancellationToken token = default)
        { throw new NotImplementedException(); }
        public Task<byte[]> GetImagePropertyAsync(int idImageProperty) { throw new NotImplementedException(); }
        public Task<bool> UpdatePricePropertyAsync(int idProperty, double price, CancellationToken token = default)
        { throw new NotImplementedException(); }
    }
}
