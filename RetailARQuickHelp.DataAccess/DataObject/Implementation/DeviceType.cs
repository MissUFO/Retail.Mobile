using System;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;
using RetailARQuickHelp.DataAccess.DataObject.Enum;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// DeviceType related for device
    /// </summary>
    public class DeviceType : Entity
    {
        public string Name { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.Name = xml.Attribute("Name").ToType<string>();
        }
    }
}
