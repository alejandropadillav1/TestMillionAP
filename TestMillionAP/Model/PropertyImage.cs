using DevExpress.Xpo;
using System;
namespace TestMillionAP.Model
{
    /// <summary>
    ///   Model Class for XPO (ORM), see the benchmarking between EF - EF Core - XPO - https://community.devexpress.com/blogs/xpo/archive/2018/07/17/xpo-a-simple-benchmark-against-ef-6-and-ef-core-update.aspx  The XPO ORM doesn't required to declare NotifyPropertyChanged event because of XPO ORM already pre built using with SetPropertyValue
    ///   automatically.
    /// </summary>
    public class PropertyImage : XPObject
    {
        bool enabled;
        byte[] file;
        Property property;
        public PropertyImage() : base()
        {
        }
        public PropertyImage(Session session) : base(session)
        {
        }
        public override void AfterConstruction() { base.AfterConstruction(); }
        public bool Enabled
        {
            get => enabled;
            set => SetPropertyValue(nameof(Enabled), ref enabled, value);
        }
        public byte[] File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [PersistentAlias("IdProperty")]
        public Property Property
        {
            get => property;
            set => SetPropertyValue(nameof(Property), ref property, value);
        }
    }
}