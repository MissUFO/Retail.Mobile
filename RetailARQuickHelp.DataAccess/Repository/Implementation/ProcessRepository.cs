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
    /// Repository for retrieving information about business processes
    /// </summary>
    public class ProcessRepository : IRepository<Process>
    {
        public string ConnectionString { get; set; }

        public ProcessRepository()
        {
            ConnectionString = DataAccess.ConnectionString.DbConnection;
        }

        /// <summary>
        /// Get list
        /// </summary>
        public List<Process> List()
        {
            var entities = new List<Process>();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Process_List]";
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
        public List<Process> List(Process entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get single item
        /// </summary>
        public Process Get(int id)
        {
            var entity = new Process();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Process_Get]";
                dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("Process"));
            }

            return entity;
        }

        /// <summary>
        /// Add or update item (NOT IMPLEMENTED)
        /// </summary>
        public Process AddEdit(Process entity)
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