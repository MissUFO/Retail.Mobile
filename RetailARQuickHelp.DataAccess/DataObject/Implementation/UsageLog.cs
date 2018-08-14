using System;
using System.Xml.Linq;
using RetailARQuickHelp.DataAccess.DataManager.Extension;
using RetailARQuickHelp.DataAccess.DataObject.Enum;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// UsageLog for user in system
    /// </summary>
    public class UsageLog : Entity
    {
        public int UserId { get; set; }
        public string PageUrl { get; set; }
        public UsageLogActionType ActionType { get; set; }
        public DateTime OccurredOn { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.UserId = xml.Attribute("UserId").ToType<int>();
            this.PageUrl = xml.Attribute("PageUrl").ToType<string>();
            this.ActionType = xml.Attribute("ActionType").ToEnum<UsageLogActionType>();
            this.OccurredOn = xml.Attribute("OccurredOn").ToType<DateTime>();
        }
    }
}
