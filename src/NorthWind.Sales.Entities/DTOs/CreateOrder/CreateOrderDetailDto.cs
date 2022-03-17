namespace NorthWind.Sales.Entities.DTOs.CreateOrder;

/// <summary>
/// representa los mismo datos de ValueObject=> OrderDetail
/// pero este será como data de entrada
/// y así mantenemos su unica responsabilidad
/// </summary>
public class CreateOrderDetailDto
{
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
}