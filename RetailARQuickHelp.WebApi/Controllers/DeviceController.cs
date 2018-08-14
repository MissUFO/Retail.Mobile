using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class DeviceController : ApiController
    {
        [HttpGet]
        [Route("api/Device/GetByQr/{qrcode}")]
        public HttpResponseMessage GetByQr(string qrcode)
        {
            var repo = new DeviceRepository();
            var entity = repo.GetByQr(qrcode);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage {Content = new StringContent(json, Encoding.UTF8, "application/json")};
        }

        [HttpGet]
        [Route("api/Device/Get/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var repo = new DeviceRepository();
            var entity = repo.Get(id);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage {Content = new StringContent(json, Encoding.UTF8, "application/json")};
        }

        [HttpGet]
        [Route("api/Device/List")]
        public HttpResponseMessage List()
        {
            var repo = new DeviceRepository();
            var entities = repo.List();

            var json = JsonConvert.SerializeObject(entities);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}
