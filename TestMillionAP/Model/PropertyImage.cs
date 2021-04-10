using DevExpress.Xpo;
using System;
namespace TestMillionAP.Model
{
    /// <summary>
    ///   Model Class for XPO (ORM), see the benchmarking between EF - EF Core - XPO - https://community.devexpress.com/blogs/xpo/archive/2018/07/17/xpo-a-simple-benchmark-against-ef-6-and-ef-core-update.aspx  The XPO ORM doesn't required to declare NotifyPropertyChanged event because of XPO ORM already pre built using with SetPropertyValue
    ///   automatically. The ORM XPO can connect with several database engine, i.e. MySQL, SQL Server, Oracle, MS Access, Google Big Query, Teradata, Amazon Redshift, Sybase, PostgreSQL, Firebird (the XPO only is a open source and free of charge).
    /// </summary>
    public class PropertyImage : XPObject
    {
        bool enabled;
        byte[] file;
        string fileName;
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
        public string FileName
        {
            get => fileName;
            set => SetPropertyValue(nameof(FileName), ref fileName, value);
        }
        public Property Property
        {
            get => property;
            set => SetPropertyValue(nameof(Property), ref property, value);
        }
    }
}