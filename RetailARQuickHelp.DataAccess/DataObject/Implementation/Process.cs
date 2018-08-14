using System;
using System.Collections.Generic;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// Process object
    /// </summary>
    public class Process : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        //public List<Image> Images
        //{
        //    get { return _images; }
        //    set { _images = value; }
        //}
        //private List<Image> _images = new List<Image>();

        public List<Document> Documents {
            get { return _documents; }
            set { _documents = value; }
        }
        private List<Document> _documents = new List<Document>();

      
        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.ImageUrl = xml.Attribute("ImageUrl").ToType<string>();
            this.Name = xml.Attribute("Name").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            
            //this.Images.UnpackXML(xml.Element("Images"));
            this.Documents.UnpackXML(xml.Element("Documents"));
        }
    }
}
