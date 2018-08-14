using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class ProcessController : ApiController
    {
        [HttpGet]
        [Route("api/Process/GetById/{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            var repo = new ProcessRepository();
            var entity = repo.Get(id);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage {Content = new StringContent(json, Encoding.UTF8, "application/json")};
        }

        [HttpGet]
        [Route("api/Process/List")]
        public HttpResponseMessage List()
        {
            var repo = new ProcessRepository();
            var entities = repo.List();

            var json = JsonConvert.SerializeObject(entities);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}
