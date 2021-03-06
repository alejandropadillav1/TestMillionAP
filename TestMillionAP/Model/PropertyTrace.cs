using DevExpress.Xpo;
using System;
namespace TestMillionAP.Model
{
    /// <summary>
    ///   Model Class for XPO (ORM), see the benchmarking between EF - EF Core - XPO - https://community.devexpress.com/blogs/xpo/archive/2018/07/17/xpo-a-simple-benchmark-against-ef-6-and-ef-core-update.aspx  The XPO ORM doesn't required to declare NotifyPropertyChanged event because of XPO ORM already pre built using with SetPropertyValue
    ///   automatically. The ORM XPO can connect with several database engine, i.e. MySQL, SQL Server, Oracle, MS Access, Google Big Query, Teradata, Amazon Redshift, Sybase, PostgreSQL, Firebird (the XPO only is a open source and free of charge).
    /// </summary>
    public class PropertyTrace : XPObject
    {
        DateTime dateSale;
        string name;
        Property property;
        double tax;
        double value1;
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
            get => value1;
            set => SetPropertyValue(nameof(Value), ref value1, value);
        }
    }
}