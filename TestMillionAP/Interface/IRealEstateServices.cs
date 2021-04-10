using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMillionAP.ModelView;
namespace TestMillionAP.Interface
{
    public interface IRealEstateServices
    {
        /// <summary>
        ///   Http post, you can add the image and convert a byte array. If the Property Id doesn't exist, it will create automatically with a default attribute.
        /// </summary>
        /// <param name="IdProperty"></param>
        /// <param name="Image"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<int> AddImageProperty(ImagePropertyModelView imageProperty, System.Threading.CancellationTokenSource token = null);
        /// <summary>
        ///   This is a http post, to create new property building (Property Table), you can complete the following attributes. If the Owner Id doesn't exist, it will create automatically with a default attribute, you can edit these following parameters into a Update View property.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public Task<int> CreatePropertyBuildingAsync(PropertyModelView propertyModelView, System.Threading.CancellationTokenSource token = null);
        /// <summary>
        ///   Bonus, return all the owner model object saved into a database.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IAsyncEnumerable<OwnerModelView> GetAllOwnerModelViewAsync(System.Threading.CancellationTokenSource token = null);
        /// <summary>
        ///   Bonus, return all Property Model saved into a Database.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IAsyncEnumerable<PropertyModelView> GetAllPropertyModelViewAsync(System.Threading.CancellationTokenSource token = null);
    }
}
