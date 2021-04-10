using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestMillionAP.Interface;
using TestMillionAP.ModelView;
namespace TestMillionAP.Services
{
    /// <summary>
    ///   Not implemented yet, it could implement using with other services engine, i.e, Redis Cache. It helps about the SOLID Principles, D Principles.
    /// </summary>
    public class RealEstateRedisServices : IRealEstateServices
    {
        public Task<bool> CreatePropertyBuildingAsync(int owner, PropertyModelView propertyModelView, CancellationTokenSource token = null)
        { throw new NotImplementedException(); }
    }
}
