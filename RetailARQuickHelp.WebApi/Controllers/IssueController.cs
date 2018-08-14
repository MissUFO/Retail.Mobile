using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.DataObject.Implementation;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class IssueController : ApiController
    {

        [HttpGet]
        [Route("api/Issue/Get/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var repo = new IssueRepository();
            var entity = repo.Get(id);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }

        [HttpGet]
        [Route("api/Issue/List/{deviceId:int}")]
        public HttpResponseMessage List(int deviceId)
        {
            var repo = new IssueRepository();
            var entity = repo.List(new Issue { DeviceId = deviceId });

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}
