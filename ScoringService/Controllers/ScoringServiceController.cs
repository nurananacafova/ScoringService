using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScoringService.Services;
using ScoringService.Utility;

namespace ScoringService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScoringServiceController : Controller
{
    private readonly IScoringService _scoringService;

    public ScoringServiceController(IScoringService scoringService)
    {
        _scoringService = scoringService;
    }


    [HttpGet("ScoreSubscriber")]
    public async Task<ActionResult<Boolean>> ScoreSubscriber([FromQuery] SimpleLoan simpleLoan)
    {
        try
        {
            Boolean result = await _scoringService.ScoreSubscriber(simpleLoan);
            return Ok(result);
        }
        catch (Exception e)
        {
            return new OkObjectResult(new ApiResponse<object>(500,
                $"Exception thrown via processing request. Method: {nameof(this.ScoreSubscriber)}, Error message: {e.Message}"));
        }
    }
}