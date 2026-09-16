namespace LegacyCode;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

public class OrderDto
{
    public int OrderId { get; set; }
    public string ShippingType { get; set; }
    public double WeightKg { get; set; }
    public double DistanceKm { get; set; }
    public bool Fragile { get; set; }
}

public class ShippingCalculator
{
    private readonly OrderApiRetriever _orderApiRetriever;

    public ShippingCalculator()
    {
        _orderApiRetriever = new OrderApiRetriever();
    }

    public double CalculateShipping(int orderId)
    {
        try
        {
            var order = _orderApiRetriever.GetOrder(orderId);

            return CalculateShipping(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
    }

    public double CalculateShipping(OrderDto? order)
    {
        if (order == null)
            throw new Exception("Failed to deserialize order");

        switch (order.ShippingType)
        {
            case "STANDARD":
                return order.WeightKg * 0.5;

            case "EXPRESS":
                return order.WeightKg * 0.8
                       + order.DistanceKm * 0.1;

            case "OVERNIGHT":
                return order.WeightKg * 1.2 + 25;

            default:
                throw new Exception($"Unknown shipping type: {order.ShippingType}");
        }
    }
}

