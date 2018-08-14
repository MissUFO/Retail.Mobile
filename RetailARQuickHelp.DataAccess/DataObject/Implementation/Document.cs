using System;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;
using RetailARQuickHelp.DataAccess.DataObject.Enum;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// Documents related for device
    /// </summary>
    public class Document : Entity
    {
        public int DeviceId { get; set; }
        public string Title { get; set; }
        public string DocumentUrl { get; set; }
        public string Description { get; set; }
        public DocumentType DocumentType { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.DeviceId = xml.Attribute("DeviceId").ToType<int>();
            this.Title = xml.Attribute("Title").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.DocumentUrl = xml.Attribute("DocumentUrl").ToType<string>();
            this.DocumentType = xml.Attribute("DocumentType").ToEnum<DocumentType>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}
