using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.DataObject.Implementation;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class DocumentController : ApiController
    {

        [HttpGet]
        [Route("api/Document/Get/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var repo = new DocumentRepository();
            var entity = repo.Get(id);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }

        [HttpGet]
        [Route("api/Document/List/{deviceId:int}")]
        public HttpResponseMessage List(int deviceId)
        {
            var repo = new DocumentRepository();
            var entity = repo.List(new Document { DeviceId = deviceId });

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}
