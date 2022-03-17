namespace NorthWind.Sales.Entities.Aggregates;

/// <summary>
/// es la forma de construir un objecto completo
/// Recordemos que tenemos separado la Order en POCO entitie
/// y por otro lado el detalle en Value Object
/// Entonces acá armamos el objecto completo padre e hijo
/// y creamos la lógica para construir el detalle
/// </summary>
public class OrderAggregate : Order
{
    /// <summary>
    /// esta variable sólo se llena en el constructor
    /// </summary>
    private readonly List<OrderDetail> OrderDetailsField =
        new List<OrderDetail>();

    /// <summary>
    /// Si me piden datos de afuera de otras capas
    /// </summary>
    public IReadOnlyCollection<OrderDetail> OrderDetails =>
        OrderDetailsField;

    /// <summary>
    /// mecanismo para ofrecer y agregar detalles
    /// </summary>
    /// <param name="orderDetail"></param>
    private void AddDetail(OrderDetail orderDetail)
    {
        //busco si existe (esto es parte del caso de uso)
        var orderDetailExisting = OrderDetailsField.FirstOrDefault(x => 
            x.ProductId == orderDetail.ProductId);

        //verificamos si existe
        if (orderDetailExisting != default)
        {
            OrderDetailsField.Add(
                //with: permite crear un nuevo objeto a partir de uno existente
                //toma el que encontró y sólo modifica el quantity
                //y lo agrego a la lista de OrderDetailsField
                orderDetailExisting with
                {
                    Quantity = (short)(orderDetailExisting.Quantity + orderDetail.Quantity)
                });

            //eliminamos el existe, dado que es parte del caso de los ValueObject
            //**no puedo modificar , sólo agregar y eliminar
            OrderDetailsField.Remove(orderDetailExisting);
        }
        else
        {
            //si no existe se agrega
            OrderDetailsField.Add(orderDetail);
        }

    }

    /// <summary>
    /// exposición pública de como agregar 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="unitPrice"></param>
    /// <param name="quantity"></param>
    public void AddDetail(int productId, decimal unitPrice, short quantity)
        => AddDetail(new OrderDetail(productId, unitPrice, quantity));

}