using Microsoft.AspNetCore.Mvc;

namespace DownstreamApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DownstreamController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new List<string> { "downstram data from API which cannot be updated", "not public, network hidden" };
    }
}
