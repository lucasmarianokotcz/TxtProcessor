using Microsoft.AspNetCore.Mvc;
using TxtProcessor.Api.Dtos;
using TxtProcessor.Core.Processing;

namespace TxtProcessor.Api.Controllers;

[ApiController]
[Route("api/")]
public class TextAnalyzerController : ControllerBase
{
    [HttpPost("analyze")]
    public IActionResult Analyze([FromBody] TextRequest request)
    {
        var result = TextAnalyzer.AnalyzeText(request.Text);
        return Ok(result);
    }
}
