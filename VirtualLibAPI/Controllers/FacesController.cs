using Autofac;
using System.Web.Http;

namespace VirtualLibAPI.Controllers
{
    public class FacesController : ApiController
    {
        private IPostHandler _ph;
       public FacesController()
        {
            _ph = WebApiApplication.container.Resolve<IPostHandler>();
        }
       

        // POST api/faces
        public int Post([FromBody]Face face)
        {
            return _ph.HandlePost(face);
        }


        // DELETE api/faces/5
        public void Delete(int id)
        {
        }
    }
}
