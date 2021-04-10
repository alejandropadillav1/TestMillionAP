using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace TestMillionAP.ModelView
{
    /// <summary>
    ///   Property Trace Class according the requirements documentation
    /// </summary>
    public class PropertyTraceModelView
    {
        [Required]
        public DateTime DateSale { get; set; }
        [Range(0, int.MaxValue)]
        public int IdProperty { get; set; }
        public int IdPropertyTrace { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Tax { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
