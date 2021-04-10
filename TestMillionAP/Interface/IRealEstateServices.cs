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
        public Task<int> AddImageProperty(ImagePropertyModelView imageProperty, System.Threading.CancellationToken token = default);
        /// <summary>
        ///   This is a http post, to create new property building (Property Table), you can complete the following attributes. If the Owner Id doesn't exist, it will create automatically with a default attribute, you can edit these following parameters into a Update View property.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public Task<int> CreatePropertyBuildingAsync(PropertyModelView propertyModelView, System.Threading.CancellationToken token = default);
        /// <summary>
        ///   This is a http post, to create new property trace, if the IdPropertyId doesn't exist, it will create automatically with a default attributes.
        /// </summary>
        /// <param name="propertyTrace"></param>
        /// <returns></returns>
        public Task<int> CreatePropertyTraceAsync(PropertyTraceModelView propertyTraceModelView, System.Threading.CancellationToken token = default);
        /// <summary>
        ///   Retrieve all IdImageProperty
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<ImagePropertyModelView> GetAllImagePropertyAsync(System.Threading.CancellationToken token = default);
        /// <summary>
        ///   Bonus, return all the owner model object saved into a database.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IAsyncEnumerable<OwnerModelView> GetAllOwnerModelViewAsync(System.Threading.CancellationToken token = default);
        /// <summary>
        ///   Bonus, return all Property Model saved into a Database.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IAsyncEnumerable<PropertyModelView> GetAllPropertyModelViewAsync(System.Threading.CancellationToken token = default);
        /// <summary>
        ///   return the  Property Trace Model filter by PropertyId saved into a Database.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IAsyncEnumerable<PropertyTraceModelView> GetAllPropertyTraceViewAsync(int IdPropertyModel, System.Threading.CancellationToken token = default);
        /// <summary>
        ///   Retrieve a Id Image if exist, otherwise it should throw an exception that doesn't exist
        /// </summary>
        /// <param name="idImageProperty"></param>
        /// <returns></returns>
        public Task<byte[]> GetImagePropertyAsync(int idImageProperty);
        /// <summary>
        ///   Update the price into a Property Id.
        /// </summary>
        /// <param name="idProperty"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public Task<bool> UpdatePricePropertyAsync(int idProperty, double price, System.Threading.CancellationToken token = default);
    }
}
