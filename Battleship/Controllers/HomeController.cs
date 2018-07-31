using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Battleship.Controllers
{
    public class HomeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }
}
