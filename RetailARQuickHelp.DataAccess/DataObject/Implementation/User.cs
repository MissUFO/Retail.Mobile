using System;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// User object
    /// </summary>
    public class User : Entity
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string FullName {
            get
            {
                return string.Join(" ", LastName,FirstName);
            }
        }

        public string Email { get; set; }

        public long EmployeeId { get; set; }
        public string PhoneNumber { get; set; }
        public int StoreId { get; set; }
        public bool Status {
            get { return _status; }
            set { _status = value;  }
        }
        private bool _status = false;

        public DateTime LastLoginOn { get; set; }

        public Store Store
        {
            get { return _store; }
            set { _store = value; }
        }
        private Store _store = new Store();

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.UserName = xml.Attribute("UserName").ToType<string>();
            this.FirstName = xml.Attribute("FirstName").ToType<string>();
            this.LastName = xml.Attribute("LastName").ToType<string>();
            this.MiddleName = xml.Attribute("MiddleName").ToType<string>();
            this.Email = xml.Attribute("Email").ToType<string>();
            this.EmployeeId = xml.Attribute("EmployeeId").ToType<long>();
            this.PhoneNumber = xml.Attribute("PhoneNumber").ToType<string>();
            this.StoreId = xml.Attribute("StoreId").ToType<int>();
            this.Status = Convert.ToBoolean(xml.Attribute("Status").ToType<int>());
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.LastLoginOn = xml.Attribute("LastLoginOn").ToType<DateTime>();

            this.Store.UnpackXML(xml.Element("Store"));

            if (string.IsNullOrEmpty(this.Email) && this.Store!=null)
            {
                this.Email = this.Store.Email;
            }
        }
    }
}
