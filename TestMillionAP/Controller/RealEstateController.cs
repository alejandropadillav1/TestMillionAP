using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpPost]
        public async Task<IActionResult> CreateBuildingPropertyAsync(PropertyModelView property)
        {
            var idBuildingProperty = await _realEstateServices.CreatePropertyBuildingAsync(property);
            return Ok(idBuildingProperty);
        }
    }
}
