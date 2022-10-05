namespace IWantApp.Domain.Orders;

public class Order : Entity 
{
    public string ClientId { get; set; }   
    public List<Product> Products { get; set; }
    public decimal Total { get; set; }  
    public string DeliveryAdress { get; set; }

    private Order() { }

    public Order (string clientId,string clientName, List<Product> products, string deliveryAdress)
    {
        ClientId = clientId;
        Products = products;
        DeliveryAdress = deliveryAdress;
        CreatedBy = clientName;
        EditedBy = clientName;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;
        this.Name = clientName;

        Total = 0;
        foreach (var item in products)
        {
            Total += item.Price;
        }

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Order>()
            .IsNotNull(ClientId, "Client")
            .IsTrue(Products != null && Products.Any(), "Products")
            .IsNotNullOrEmpty(DeliveryAdress, "DeliveryAddress");
        AddNotifications(contract);
    }
}
