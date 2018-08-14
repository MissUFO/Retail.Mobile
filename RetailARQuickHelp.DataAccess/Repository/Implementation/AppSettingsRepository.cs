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
    /// Repository for retrieving information about AppSettings
    /// </summary>
    public class AppSettingsRepository : IRepository<AppSettings>
    {
        public string ConnectionString { get; set; }

        public AppSettingsRepository()
        {
            ConnectionString = DataAccess.ConnectionString.DbConnection;
        }

        /// <summary>
        /// Get list
        /// </summary>
        public List<AppSettings> List()
        {
            var entities = new List<AppSettings>();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[conf].[AppSettings_List]";
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
        public List<AppSettings> List(AppSettings entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get single item by key
        /// </summary>
        public AppSettings GetByKey(string key)
        {
            var entity = new AppSettings();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[conf].[AppSettings_GetByKey]";
                dataManager.Add("@Key", SqlDbType.NVarChar, ParameterDirection.Input, key);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("AppSetting"));
            }

            return entity;
        }

        /// <summary>
        /// Get single item  (NOT IMPLEMENTED)
        /// </summary>
        public AppSettings Get(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Add or update item (NOT IMPLEMENTED)
        /// </summary>
        public AppSettings AddEdit(AppSettings entity)
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