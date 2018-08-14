using System;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// User object
    /// </summary>
    public class Store : Entity
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Address { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.StoreId = xml.Attribute("StoreId").ToType<int>();
            this.Name = xml.Attribute("Name").ToType<string>();
            this.Address = xml.Attribute("Address").ToType<string>();
        }
    }
}
