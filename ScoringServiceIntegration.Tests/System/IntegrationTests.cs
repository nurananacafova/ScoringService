using System.Net;
using Newtonsoft.Json;
using ScoringService;
using WireMock.Server;

namespace ScoringServiceIntegration.Tests.System;

public class IntegrationTests
{
    [Fact]
    public async Task ScoreSubscriber_ReturnsTrue()
    {
        var server = WireMockServer.Start();
        var httpClient = server.CreateClient();
        httpClient.BaseAddress = new Uri($"http://localhost:{5004}");
        var request = new SimpleLoan()
        {
            id = 6,
            amount = 234
        };
        var response =
            await httpClient.GetAsync($"/api/ScoringService/ScoreSubscriber?id={request.id}&amount={request.amount}");
        var body = await response.Content.ReadAsStringAsync();
        var actualResult = JsonConvert.DeserializeObject<bool>(body);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response);
        Assert.True(actualResult == true);
    }

    [Fact]
    public async Task ScoreSubscriber_ReturnsFalse()
    {
        var server = WireMockServer.Start();
        var httpClient = server.CreateClient();
        httpClient.BaseAddress = new Uri($"http://localhost:{5004}");
        var request = new SimpleLoan()
        {
            id = 1,
            amount = 234
        };
        var response =
            await httpClient.GetAsync($"/api/ScoringService/ScoreSubscriber?id={request.id}&amount={request.amount}");
        var body = await response.Content.ReadAsStringAsync();
        var actualResult = JsonConvert.DeserializeObject<bool>(body);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response);
        Assert.True(actualResult == false);
    }
}