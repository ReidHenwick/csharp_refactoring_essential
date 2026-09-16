using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LegacyCode.Test;

[TestFixture]
public sealed class ShippingCalculatorTest
{
    [Test]
    [TestCase("STANDARD", 0.5)]
    [TestCase("EXPRESS", 0.9)]
    [TestCase("OVERNIGHT", 26.2)]
    public void CalculatingShippingCalculatesShipping(string orderType, double expectedCost)
    {
        var input = new OrderDto()
        {
            OrderId = 1001,
            DistanceKm = 1,
            Fragile = false,
            ShippingType = orderType,
            WeightKg = 1
        };

        var shippingCalculator = new ShippingCalculator();

        var result = shippingCalculator.CalculateCost(input);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(expectedCost));
    }

    [Test]
    public void CalculatingShippingForNullOrder()
    {
        var shippingCalculator = new ShippingCalculator();

        Assert.That(() => shippingCalculator.CalculateCost(null), Throws.InstanceOf<Exception>());
    }
}