using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class AppSettingsController : ApiController
    {
        [HttpGet]
        [Route("api/AppSettings/GetByKey/{key}")]
        public HttpResponseMessage GetByKey(string key)
        {
            var repo = new AppSettingsRepository();
            var entity = repo.GetByKey(key);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage {Content = new StringContent(json, Encoding.UTF8, "application/json")};
        }

        [HttpGet]
        [Route("api/AppSettings/List")]
        public HttpResponseMessage List()
        {
            var repo = new AppSettingsRepository();
            var entities = repo.List();

            var json = JsonConvert.SerializeObject(entities);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}
