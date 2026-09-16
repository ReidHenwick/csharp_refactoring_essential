namespace DivergentChange.Test;

using NUnit.Framework;

[TestFixture]
public class CustomerServiceTest
{
    private readonly CustomerService service = new CustomerService();

    // -------------------------
    // formatDisplayName tests
    // -------------------------

    [Test]
    public void FormatDisplayName_shouldTrimAndUppercaseLastName()
    {
        string result = service.FormatDisplayName(" John ", " smith ");
        Assert.AreEqual("John SMITH", result);
    }

    [Test]
    public void FormatDisplayName_shouldHandleEmptyStrings()
    {
        string result = service.FormatDisplayName("", "");
        Assert.AreEqual(" ", result);
    }

    [Test]
    public void FormatDisplayName_shouldHandleSingleCharacterNames()
    {
        string result = service.FormatDisplayName("A", "b");
        Assert.AreEqual("A B", result);
    }

    // -------------------------
    // calculateLoyaltyPoints tests
    // -------------------------

    [Test]
    public void CalculateLoyaltyPoints_shouldReturnZero_whenNoPurchases()
    {
        Assert.AreEqual(0, service.CalculateLoyaltyPoints(0));
    }

    [Test]
    public void CalculateLoyaltyPoints_shouldCalculateCorrectly_forPositiveValues()
    {
        Assert.AreEqual(50, service.CalculateLoyaltyPoints(5));
    }

    [Test]
    public void CalculateLoyaltyPoints_shouldHandleLargeNumbers()
    {
        Assert.AreEqual(100_000, service.CalculateLoyaltyPoints(10_000));
    }

    [Test]
    public void CalculateLoyaltyPoints_shouldAllowNegativeValues_butStillMultiply()
    {
        Assert.AreEqual(-50, service.CalculateLoyaltyPoints(-5));
    }

    // -------------------------
    // determineAccountStatus tests
    // -------------------------

    [Test]
    public void DetermineAccountStatus_shouldReturnInactive_whenDaysOver365()
    {
        Assert.AreEqual("INACTIVE", service.DetermineAccountStatus(366));
    }

    [Test]
    public void DetermineAccountStatus_shouldReturnDormant_whenBetween31And365()
    {
        Assert.AreEqual("DORMANT", service.DetermineAccountStatus(100));
    }

    [Test]
    public void DetermineAccountStatus_shouldReturnActive_when30DaysOrLess()
    {
        Assert.AreEqual("ACTIVE", service.DetermineAccountStatus(30));
        Assert.AreEqual("ACTIVE", service.DetermineAccountStatus(0));
    }

    [Test]
    public void DetermineAccountStatus_shouldTreatNegativeDaysAsActive()
    {
        Assert.AreEqual("ACTIVE", service.DetermineAccountStatus(-10));
    }
}