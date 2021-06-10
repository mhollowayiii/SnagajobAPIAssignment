using SnagajobAPIAssignment.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace SnagajobAPIAssignment.Controllers
{
    public class ValuesController : ApiController
    {
        // TODO: We'd want to make this scalable in a real world application
        private ApplicationManagement appManager = new ApplicationManagement();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return appManager.FetchApplications();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] Application app)
        {
            ApplicationManagement appChecker = new ApplicationManagement();
            appChecker.ProcessApplication(app);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
