using System;
using System.Linq;
namespace TestMillionAP.ModelView
{
    /// <summary>
    ///   Interact the model-view Owner Model View property
    /// </summary>
    public class OwnerModelView
    {
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}
