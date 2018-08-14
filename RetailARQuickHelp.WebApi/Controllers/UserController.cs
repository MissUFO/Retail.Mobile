using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.DataObject.Implementation;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/User/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var repo = new UserRepository();
            var entity = repo.Get(id);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }

        [HttpGet]
        [Route("api/User/LogIn/{login}/{password}")]
        public HttpResponseMessage LogIn(string login, string password)
        {
            var repository = new UserRepository();

            var json = CreatorsHubLogin(login, password);
            var result = JsonConvert.DeserializeObject<dynamic>(json);
            if (result.result != null && result.result == 1)
            {
                var entity = repository.Login(login);
                if (entity == null || entity.Id == 0)
                    entity = repository.AddEdit(new User()
                    {
                        UserName = login,
                        EmployeeId = Convert.ToInt32(result.uid),
                        FirstName = result.first_name,
                        LastName = result.last_name,
                        MiddleName = result.middle_name,
                        Status = true
                    });

                json = JsonConvert.SerializeObject(entity);
            }

            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }

        [HttpGet]
        [Route("api/User/LogOff/{login}")]
        public HttpResponseMessage LogOff(string login)
        {
            var entity = new { OK = true };

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }

        private string CreatorsHubLogin(string login, string password)
        {
            var creatorshubUrl = new AppSettingsRepository().GetByKey("CREATORSHUB_LOGIN_URL").Value;
            var creatorshubApiKey = new AppSettingsRepository().GetByKey("CREATORSHUB_LOGIN_API_KEY").Value;

            string result;
            try
            {
                using (var client = new WebClient())
                {

                    byte[] response =
                        client.UploadValues(creatorshubUrl, new NameValueCollection()
                        {
                            { "api_key", creatorshubApiKey },
                            { "login", login },
                            { "password", password }
                        });

                    result = Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception ex)
            {
                result = "{'result': 0, 'error':'"+ex.Message+"'}";
            }

            return result;
        }
    }
}
