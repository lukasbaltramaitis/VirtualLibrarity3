using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VirtualLibAPI;
using VirtualLibrarity.Models;

namespace VirtualLibrarity.Controllers
{
    public class RegistrationController : ApiController
    {
        private IPostHandler _ph;
        public RegistrationController()
        {
            _ph = WebApiApplication.container.Resolve<IPostHandler>();
        }
        // GET: api/Registration
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registration/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Registration
        public int Post([FromBody] RegisterArgs regArgs)
        {
            return _ph.HandleRegisterPost(regArgs);
        }

        // PUT: api/Registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Registration/5
        public void Delete(int id)
        {
        }
    }
}
