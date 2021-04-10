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
    public class PropertyTrace : XPObject
    {
        DateTime dateSale;
        string name;
        Property property;
        double tax;
        double value;
        public PropertyTrace() : base()
        {
        }
        public PropertyTrace(Session session) : base(session)
        {
        }
        public override void AfterConstruction() { base.AfterConstruction(); }
        public DateTime DateSale
        {
            get => dateSale;
            set => SetPropertyValue(nameof(DateSale), ref dateSale, value);
        }
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        [PersistentAlias("IdProperty")]
        public Property Property
        {
            get => property;
            set => SetPropertyValue(nameof(Property), ref property, value);
        }
        public double Tax
        {
            get => tax;
            set => SetPropertyValue(nameof(Tax), ref tax, value);
        }
        public double Value
        {
            get => value;
            set => SetPropertyValue(nameof(Value), ref value, value);
        }
    }
}