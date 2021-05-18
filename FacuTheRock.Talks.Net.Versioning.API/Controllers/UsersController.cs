using Microsoft.AspNetCore.Mvc;

namespace FacuTheRock.Talks.Net.Versioning.API.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [Route("api/users")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    public class UsersController : ControllerBase
    {
        [HttpGet("{userId:int}")]
        public IActionResult GetV1([FromRoute] int userId)
        {
            var user = new
            {
                Id = userId,
                Name = "Net-Baires"
            };

            return Ok(user);
        }

        [HttpGet("{userId:int}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2([FromRoute] int userId)
        {
            var user = new
            {
                Id = userId,
                UserName = "Net-Baires"
            };

            return Ok(user);
        }
    }
}
