namespace ScoringService.Utility;

public interface ISubscriberClientHelper
{
    Task<SubscriberModel> GetSubscriber(int id);
}