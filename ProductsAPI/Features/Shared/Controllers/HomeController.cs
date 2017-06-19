using AutoMapper;
using System.Web.Http;

namespace ProductsAPI.Features.Shared.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Web API Started successfully";
        }
    }
}