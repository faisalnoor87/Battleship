using System;
using Battleship.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Battleship.Controllers
{
    [RoutePrefix("api/battleship")]
    public class GameController : ApiController
    {
        [Route("setup")]
        [HttpPost]
        public HttpResponseMessage Setup(Commands.SetupCommand setupCommand)
        {
            try
            {
                Storage.Console.Setup(setupCommand);
                return Request?.CreateResponse(HttpStatusCode.OK, "setup successfull");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("hit")]
        [HttpPut]
        public HttpResponseMessage Hit(Commands.HitCommand hitCommand)
        {
            var status = Storage.Console.Hit(hitCommand);
            return Request?.CreateResponse(HttpStatusCode.OK, status);
        }
    }
}
