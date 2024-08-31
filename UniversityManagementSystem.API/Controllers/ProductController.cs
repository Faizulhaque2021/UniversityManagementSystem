using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagementSystem.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductController : ApiBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hellow Product");
        }
    }
}
