using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMillionAP.Interface;
using TestMillionAP.ModelView;
namespace TestMillionAP.Controller
{
    // A large Real Estate company requires creating an API to obtain information about properties in the United States, this is in a database as shown in the image, its task is to create a set of services:
    // a)	Create Property Building
    // b)	Add Image from property
    // c)	Change Price
    // d)	Update Views property
    // e)	List property with filters
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class RealEstateController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRealEstateServices _realEstateServices;
        public RealEstateController(IRealEstateServices realEstateServices)
        { _realEstateServices = realEstateServices; }
        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();
            foreach(var entry in modelState)
            {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }
            return String.Join(" ", messages);
        }
        /// <summary>
        ///   b) Add Image from property
        /// </summary>
        /// <param name="imageProperty"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddImagePropertyAsync([FromForm] ImagePropertyModelView imageProperty)
        {
            if(!TryValidateModel(imageProperty))
                return BadRequest(GetFullErrorMessage(ModelState));
            var idImageProperty = await _realEstateServices.AddImageProperty(imageProperty);
            return Ok(idImageProperty);
        }
        /// <summary>
        ///   a) Create Building Property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBuildingPropertyAsync([FromForm]PropertyModelView property)
        {
            if(!TryValidateModel(property))
                return BadRequest(GetFullErrorMessage(ModelState));
            var idBuildingProperty = await _realEstateServices.CreatePropertyBuildingAsync(property);
            return Ok(idBuildingProperty);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePropertyTraceBuilding([FromForm] PropertyTraceModelView propertyTrace)
        {
            if(!TryValidateModel(propertyTrace))
                return BadRequest(GetFullErrorMessage(ModelState));
            var idPropertyTrace = await _realEstateServices.CreatePropertyTraceAsync(propertyTrace);
            return Ok(idPropertyTrace);
        }
        /// <summary>
        ///   Bonus Section, return all owner view stored into a database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async IAsyncEnumerable<OwnerModelView> GetAllOwnerModelViewAsync()
        {
            await foreach(var ownerItem in _realEstateServices.GetAllOwnerModelViewAsync())
            {
                yield return ownerItem;
            }
        }
        /// <summary>
        ///   Bonus section, getting all Property View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async IAsyncEnumerable<PropertyModelView> GetAllPropertyModelViewAsync()
        {
            await foreach(var propertyItem in _realEstateServices.GetAllPropertyModelViewAsync())
            {
                yield return propertyItem;
            }
        }
    }
}
