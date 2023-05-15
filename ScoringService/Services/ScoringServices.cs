using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ScoringService.Utility;

namespace ScoringService.Services;

public class ScoringServices : IScoringService
{
    private readonly ILogger<ScoringServices> _logger;
    private ISubscriberClientHelper _helper;

    public ScoringServices(ILogger<ScoringServices> logger, ISubscriberClientHelper helper)
    {
        _logger = logger;
        _helper = helper;
    }


    public async Task<bool> ScoreSubscriber(SimpleLoan simpleLoan)
    {
        SubscriberModel subscriber;
        DateTime registrationDate;
        Boolean canGetLoan = false;
        try
        {
            subscriber = await _helper.GetSubscriber(simpleLoan.id);
            if (subscriber != null)
            {
                registrationDate = subscriber.registration_date;
                canGetLoan = ScoringServiceHelper.GetDays(registrationDate, 60, simpleLoan.amount);


                _logger.LogInformation(
                    "Amount:{amount}, Registration date:{registration}, Has been registered for more than a given time:{difference}",
                    $"{simpleLoan.amount}",
                    $"{registrationDate.ToShortDateString()}", $"{canGetLoan}");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

        return canGetLoan;
    }
}