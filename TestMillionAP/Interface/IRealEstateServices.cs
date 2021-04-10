using System;
using System.Linq;
using System.Threading.Tasks;
using TestMillionAP.ModelView;
namespace TestMillionAP.Interface
{
    public interface IRealEstateServices
    {
        /// <summary>
        ///   If the Owner doesn't exist, it creates automatically.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public Task<int> CreatePropertyBuildingAsync(PropertyModelView propertyModelView, System.Threading.CancellationTokenSource token = null);
    }
}
