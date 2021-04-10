using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace TestMillionAP.ModelView
{
    public class ImagePropertyModelView
    {
        [Required]
        public IFormFile File { get; set; }
        public int IdImageProperty { get; set; }
        public int IdProperty { get; set; }
    }
}
