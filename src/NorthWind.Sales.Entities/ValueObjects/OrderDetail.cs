namespace NorthWind.Sales.Entities.ValueObjects;

/// <summary>
/// de tipo inmutable
/// representa el detalle de una order
/// </summary>
public record struct OrderDetail(int ProductId,
    decimal UnitPrice,
    short Quantity);
