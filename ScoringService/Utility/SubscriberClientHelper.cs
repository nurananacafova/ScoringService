using Newtonsoft.Json;

namespace ScoringService.Utility;

public class SubscriberClientHelper : ISubscriberClientHelper
{
    private HttpClient _client = new HttpClient();
    private readonly Uri _subscriberServiceUrl = new Uri("http://subscriber:5000/api/Subscribers/GetSubscriber/");

    public SubscriberClientHelper()
    {
        _client.BaseAddress = _subscriberServiceUrl;
    }


    public virtual async Task<SubscriberModel> GetSubscriber(int id)
    {
        SubscriberModel subscriber;

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(_subscriberServiceUrl + $"?id={id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                subscriber = JsonConvert.DeserializeObject<SubscriberModel>(apiResponse);
            }
        }

        return subscriber;
    }
}