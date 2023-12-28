using Microsoft.AspNetCore.Mvc;
using NetAPI2.Models;

namespace NetAPI2.Controllers;

[Route("api/demo")]
[ApiController]
public class DemoController : ControllerBase
{
    [HttpPost("get-data")]
    public async Task<ActionResult> GetData(DemoRequestData demoRequestData)
    {
        string result = $"Data return: {demoRequestData?.QueryName}";
        return Ok(result);
    }
}