using ScoringService;

namespace ScoringServiceUnit.Tests.MockData;

public class SubscriberMockData
{
    public static SimpleLoan ReturnFalse()
    {
        return new SimpleLoan
        {
            id = 1,
            amount = 2345
        };
    }

    public static SimpleLoan ReturnTrue()
    {
        return new SimpleLoan
        {
            id = 1,
            amount = 2345
        };
    }
}
