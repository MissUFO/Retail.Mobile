using System;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.DataObject.Enum;
using RetailARQuickHelp.DataAccess.DataObject.Implementation;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class UsageLogController : ApiController
    {
        [HttpGet]
        [Route("api/UsageLog/Add/{userId}/{pageUrl}/{actionType}")]
        public HttpResponseMessage AddEdit(int userId, string pageUrl, byte actionType)
        {
            //Read = 0,
            //Login = 1,
            //Logoff = 2,
            //Write = 3,
            //Search = 4,
            //Scan = 5
            var usageLog = new UsageLog()
            {
                UserId = userId,
                PageUrl = pageUrl,
                ActionType = (UsageLogActionType)actionType,
                OccurredOn = DateTime.Now
            };
            var repo = new UsageLogRepository();
            var entity = repo.AddEdit(usageLog);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}
