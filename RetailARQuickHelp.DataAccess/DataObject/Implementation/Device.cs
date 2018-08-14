using System;
using System.Collections.Generic;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// Device object
    /// </summary>
    public class Device : Entity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public List<Barcode> Barcodes
        {
            get { return _barcodes; }
            set { _barcodes = value; }
        }
        private List<Barcode> _barcodes = new List<Barcode>();

        public string ImageUrl { get; set; }

        public DeviceType DeviceType
        {
            get { return _deviceType; }
            set { _deviceType = value; }
        }
        private DeviceType _deviceType = new DeviceType();

        public List<Image> Images
        {
            get { return _images; }
            set { _images = value; }
        }
        private List<Image> _images = new List<Image>();

        public List<Document> Documents {
            get { return _documents; }
            set { _documents = value; }
        }
        private List<Document> _documents = new List<Document>();

        public List<Issue> Issues
        {
            get { return _issues; }
            set { _issues = value; }
        }
        private List<Issue> _issues = new List<Issue>();

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.ImageUrl = xml.Attribute("ImageUrl").ToType<string>();
            this.Name = xml.Attribute("Name").ToType<string>();
            this.Model = xml.Attribute("Model").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();

            this.DeviceType.UnpackXML(xml.Element("DeviceType"));

            this.Images.UnpackXML(xml.Element("Images"));
            this.Barcodes.UnpackXML(xml.Element("Barcodes"));
            this.Documents.UnpackXML(xml.Element("Documents"));
            this.Issues.UnpackXML(xml.Element("Issues"));
        }
    }
}
