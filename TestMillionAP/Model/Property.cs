using DevExpress.Xpo;
using System;
namespace TestMillionAP.Model
{
    /// <summary>
    ///   Model Class for XPO (ORM), see the benchmarking between EF - EF Core - XPO - https://community.devexpress.com/blogs/xpo/archive/2018/07/17/xpo-a-simple-benchmark-against-ef-6-and-ef-core-update.aspx  The XPO ORM doesn't required to declare NotifyPropertyChanged event because of XPO ORM already pre built using with SetPropertyValue
    ///   automatically. The ORM XPO can connect with several database engine, i.e. MySQL, SQL Server, Oracle, MS Access, Google Big Query, Teradata, Amazon Redshift, Sybase, PostgreSQL, Firebird (the XPO only is a open source and free of charge).
    /// </summary>
    public class Property : XPObject
    {
        string address;
        string codeInternal;
        string name;
        Owner owner;
        double price;
        int year;
        public Property() : base()
        {
        }
        public Property(Session session) : base(session)
        {
        }
        public override void AfterConstruction() { base.AfterConstruction(); }
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }
        public string CodeInternal
        {
            get => codeInternal;
            set => SetPropertyValue(nameof(CodeInternal), ref codeInternal, value);
        }
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        public Owner Owner
        {
            get => owner;
            set => SetPropertyValue(nameof(Owner), ref owner, value);
        }
        public double Price
        {
            get => price;
            set => SetPropertyValue(nameof(Price), ref price, value);
        }
        public int Year
        {
            get => year;
            set => SetPropertyValue(nameof(Year), ref year, value);
        }
    }
}