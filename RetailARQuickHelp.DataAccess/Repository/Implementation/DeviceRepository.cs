using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;
using RetailARQuickHelp.DataAccess.DataObject.Implementation;
using RetailARQuickHelp.DataAccess.Repository.Interface;

namespace RetailARQuickHelp.DataAccess.Repository.Implementation
{
    /// <summary>
    /// Repository for retrieving information about devices
    /// </summary>
    public class DeviceRepository : IRepository<Device>
    {
        public string ConnectionString { get; set; }

        public DeviceRepository()
        {
            ConnectionString = DataAccess.ConnectionString.DbConnection;
        }

        /// <summary>
        /// Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<Device> List()
        {
            var entities = new List<Device>();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Device_List]";
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entities.UnpackXML(xmlOut);
            }

            return entities;
        }

        /// <summary>
        /// Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<Device> List(Device entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get single item by QR code
        /// </summary>
        public Device GetByQr(string qrcode)
        {
            var entity = new Device();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Device_GetByOR]";
                dataManager.Add("@QRCode", SqlDbType.NVarChar, ParameterDirection.Input, qrcode);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("Device"));
            }

            return entity;
        }

        /// <summary>
        /// Get single item
        /// </summary>
        public Device Get(int id)
        {
            var entity = new Device();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Device_Get]";
                dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("Device"));
            }

            return entity;
        }

        /// <summary>
        /// Add or update item (NOT IMPLEMENTED)
        /// </summary>
        public Device AddEdit(Device entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Delete single item (NOT IMPLEMENTED)
        /// </summary>
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}