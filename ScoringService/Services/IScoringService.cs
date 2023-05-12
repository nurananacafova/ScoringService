using Microsoft.AspNetCore.Mvc;

namespace ScoringService.Services;

public interface IScoringService
{
    Task<Boolean> ScoreSubscriber([FromQuery] SimpleLoan simpleLoan);
}