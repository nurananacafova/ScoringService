using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace ScoringService.Utility;

public class ScoringServiceHelper
{
    private static HttpClientHandler _clientHandler = new HttpClientHandler();
    private readonly ILogger<ScoringServiceHelper> _logger;

    public ScoringServiceHelper(ILogger<ScoringServiceHelper> logger)
    {
        _logger = logger;
        _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
        {
            return true;
        };
    }

    public static Boolean GetDays(DateTime startDate, int dayCount, int amount)
    {
        if (amount <= 1000)
        {
            dayCount = 30;
        }
        else if (amount > 1000)
        {
            dayCount = 60;
        }

        // startDate = new DateTime(2023, 03, 29);
        DateTime endDate = DateTime.Now;
        TimeSpan difference = endDate.Subtract(startDate);
        int dayDifference = difference.Days;
        Console.WriteLine($"how many days have been registered:{dayDifference}");
        if (dayDifference > dayCount)
        {
            return true;
        }

        return false;
    }
}