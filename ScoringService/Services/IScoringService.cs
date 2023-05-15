using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScoringService.Services;

public interface IScoringService
{
    Task<Boolean> ScoreSubscriber([FromQuery] SimpleLoan simpleLoan);
}