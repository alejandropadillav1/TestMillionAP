using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace TestMillionAP.ModelView
{
    public class PropertyModelView
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string CodeInternal { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Id Owner should be greater than 0")]
        public int IdOwner { get; set; }
        public int IdProperty { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
