using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VirtualLibrarity.DataWorkers;
using VirtualLibrarity.Models;
using VirtualLibrarity.Models.Entities;

namespace VirtualLibrarity.Controllers
{
    public class ManualLoginController : ApiController
    {
        // GET: api/ManualLogin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ManualLogin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ManualLogin
        public UserToLoginResponse Post([FromBody]LoginManualArgs loginManualArgs)
        {
            return new UserToLoginResponseBuilder().BuildUserToSend(loginManualArgs);
        }

        // PUT: api/ManualLogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ManualLogin/5
        public void Delete(int id)
        {
        }
    }
}
