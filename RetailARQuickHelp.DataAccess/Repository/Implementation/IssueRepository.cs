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
    /// Issues. For now the only getting list of issues from database
    /// </summary>
    public class IssueRepository : IRepository<Issue>
    {
        public string ConnectionString { get; set; }

        public IssueRepository()
        {
            ConnectionString = DataAccess.ConnectionString.DbConnection;
        }

        /// <summary>
        ///Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<Issue> List()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list by deviceId
        /// </summary>
        public List<Issue> List(Issue entity)
        {
            var entities = new List<Issue>();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Issue_List]";
                dataManager.Add("@deviceId", SqlDbType.Int, ParameterDirection.Input, entity.DeviceId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entities.UnpackXML(xmlOut);
            }

            return entities;
        }

        /// <summary>
        /// Get single item
        /// </summary>
        public Issue Get(int id)
        {
            var entity = new Issue();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Issue_Get]";
                dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("Issue"));
            }

            return entity;
        }

        /// <summary>
        /// Add or update item (NOT IMPLEMENTED)
        /// </summary>
        public Issue AddEdit(Issue entity)
        {
            throw new NotImplementedException();
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
