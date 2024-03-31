using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DownstreamApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
public class DownstreamController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return ["downstram data from API which cannot be updated", "not public, network hidden"];
    }
}
