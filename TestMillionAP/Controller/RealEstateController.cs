using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestMillionAP.Interface;
using TestMillionAP.ModelView;
namespace TestMillionAP.Controller
{
    public class RealEstateController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRealEstateServices _realEstateServices;
        public RealEstateController(IRealEstateServices realEstateServices)
        { _realEstateServices = realEstateServices; }
        [HttpPost]
        public async Task<IActionResult> CreateBuildingPropertyAsync(int idowner, PropertyModelView property)
        {
            var idBuildingProperty = await _realEstateServices.CreatePropertyBuildingAsync(idowner, property);
            return Ok(idBuildingProperty);
        }
    }
}
