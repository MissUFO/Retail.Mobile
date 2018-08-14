using System;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;
using RetailARQuickHelp.DataAccess.DataObject.Enum;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// Images related for device
    /// </summary>
    public class Image : Entity
    {
        public int DeviceId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.DeviceId = xml.Attribute("DeviceId").ToType<int>();
            this.Title = xml.Attribute("Title").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.Url = xml.Attribute("Url").ToType<string>();
            this.Order = xml.Attribute("Order").ToType<int>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}
