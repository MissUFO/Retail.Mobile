using System;
using System.Collections.Generic;
using System.Data;
using RetailARQuickHelp.DataAccess.DataObject.Implementation;
using RetailARQuickHelp.DataAccess.Repository.Interface;

namespace RetailARQuickHelp.DataAccess.Repository.Implementation
{
    /// <summary>
    /// Save information about users usages
    /// </summary>
    public class UsageLogRepository : IRepository<UsageLog>
    {
        public string ConnectionString { get; set; }

        public UsageLogRepository()
        {
            ConnectionString = DataAccess.ConnectionString.DbConnection;
        }

        /// <summary>
        /// Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<UsageLog> List()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<UsageLog> List(UsageLog entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get single item (NOT IMPLEMENTED)
        /// </summary>
        public UsageLog Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add or update item
        /// </summary>
        public UsageLog AddEdit(UsageLog entity)
        {
           
            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[logs].[UsageLog_AddEdit]";
                dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
                dataManager.Add("@ActionType", SqlDbType.Int, ParameterDirection.Input, (int)entity.ActionType);
                dataManager.Add("@PageUrl", SqlDbType.NVarChar, ParameterDirection.Input, entity.PageUrl);
                dataManager.Add("@OccurredOn", SqlDbType.DateTime, ParameterDirection.Input, entity.OccurredOn);
                
                dataManager.ExecuteNonQuery();
                
            }

            return entity;
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