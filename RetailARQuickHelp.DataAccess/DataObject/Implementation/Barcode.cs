using System;
using System.Collections.Generic;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// Device barcode
    /// </summary>
    public class Barcode : Entity
    {
        public string Code { get; set; }
        public int DeviceId { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.Code = xml.Attribute("Code").ToType<string>();
            this.DeviceId = xml.Attribute("DeviceId").ToType<int>();
        }
    }
}
