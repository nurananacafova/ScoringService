using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using ScoringService;
using ScoringService.Services;
using ScoringService.Utility;
using ScoringServiceUnit.Tests.MockData;
using Xunit;

namespace ScoringServiceUnit.Tests.System;

public class TestScoringService
{
    [Fact]
    public async Task ScoreSubscriber_ReturnsOk()
    {
        var mockSubscriberClientHelper = new Mock<SubscriberClientHelper>();

        mockSubscriberClientHelper.Setup(x => x.GetSubscriber(1))
            .ReturnsAsync(new SubscriberModel
            {
                id = 1,
                language = "az",
                email = "newmailfortests1@gmail.com",
                registration_date = Convert.ToDateTime("2022-04-04")
            });

        var mockLogger = new Mock<ILogger<ScoringServices>>();

        var sut = new ScoringServices(mockLogger.Object, mockSubscriberClientHelper.Object);

        var result = await sut.ScoreSubscriber(SubscriberMockData.ReturnTrue());
        Assert.True(result);
    }

    [Fact]
    public async Task ScoreSubscriber_ReturnsFalse()
    {
        var mockSubscriberClientHelper = new Mock<SubscriberClientHelper>();

        mockSubscriberClientHelper.Setup(x => x.GetSubscriber(1))
            .ReturnsAsync(new SubscriberModel
            {
                id = 1,
                // amount = 2345
                language = "az",
                email = "newmailfortests1@gmail.com",
                registration_date = Convert.ToDateTime("2023-04-04")
            });

        var mockLogger = new Mock<ILogger<ScoringServices>>();

        var sut = new ScoringServices(mockLogger.Object, mockSubscriberClientHelper.Object);

        var result = await sut.ScoreSubscriber(SubscriberMockData.ReturnFalse());
        Assert.False(result);
    }
}