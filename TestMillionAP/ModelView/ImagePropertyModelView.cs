using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
namespace TestMillionAP.ModelView
{
    public class ImagePropertyModelView
    {
        public IFormFile File { get; set; }
        public int IdProperty { get; set; }
    }
}
