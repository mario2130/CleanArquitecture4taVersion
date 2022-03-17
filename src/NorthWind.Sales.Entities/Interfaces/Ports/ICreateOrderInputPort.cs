

namespace NorthWind.Sales.Entities.Interfaces.Ports;

/// <summary>
/// ****sirve para asignar roles a otras clases cuando no tiene definido ningún mienbro
/// </summary>
public interface ICreateOrderInputPort
{
    ValueTask Handle(CreateOrderDto orderDto);
}