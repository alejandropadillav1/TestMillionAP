using DevExpress.Xpo;
using System;
namespace TestMillionAP.Model
{
    /// <summary>
    ///   Model Class for XPO (ORM), see the benchmarking between EF - EF Core - XPO -
    ///   https://community.devexpress.com/blogs/xpo/archive/2018/07/17/xpo-a-simple-benchmark-against-ef-6-and-ef-core-
    ///   update.aspx The XPO ORM doesn't required to declare NotifyPropertyChanged event because of XPO ORM already pre
    ///   built using with SetPropertyValue automatically.
    /// </summary>
    public class Owner : XPObject
    {
        string address;
        DateTime birthday;
        string name;
        byte[] photo;
        public Owner() : base()
        {
        }
        public Owner(Session session) : base(session)
        {
        }
        public override void AfterConstruction() { base.AfterConstruction(); }
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }
        public DateTime Birthday
        {
            get => birthday;
            set => SetPropertyValue(nameof(Birthday), ref birthday, value);
        }
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        [Size(SizeAttribute.Unlimited)]
        public byte[] Photo
        {
            get => photo;
            set => SetPropertyValue(nameof(Photo), ref photo, value);
        }
    }
}