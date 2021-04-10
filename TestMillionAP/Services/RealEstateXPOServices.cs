using DevExpress.Xpo;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestMillionAP.Interface;
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
        public Task<bool> CreatePropertyBuildingAsync(int owner, PropertyModelView propertyModelView, CancellationTokenSource token = null)
        { throw new NotImplementedException(); }
    }
}
