using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class OrderSupply
    {
        public int SupplyOrderID { get; init; }
        public Supplier? _supplierID { get; set; }
        public Product? _productID { get; set; }
        public int ProductAmount { get; init; }
        public string OrderTime { get; set; }
        public Employee? _employeeID { get; set; }


        public OrderSupply()
        {

        }

        public OrderSupply(int orderID, int productAmount)
        {
            SupplyOrderID = orderID;
            ProductAmount = productAmount;
        }

        public OrderSupply(int orderID, int productAmount, string orderTime)
        {
            SupplyOrderID = orderID;
            ProductAmount = productAmount;
            OrderTime = orderTime;
        }

        public OrderSupply(int orderID, Supplier supplierID, Product productID, int productAmount, string orderTime, Employee employeeID)
        {
            SupplyOrderID = orderID;
            _supplierID = supplierID;
            _productID = productID;
            ProductAmount = productAmount;
            OrderTime = orderTime;
            _employeeID = employeeID;
        }

        public override string ToString()
        {
            return $"Supply order ID: {SupplyOrderID}, Supplier: {_supplierID}, Product: {_productID}, Product Amount: {ProductAmount}, Order time: {OrderTime}, Employee: {_employeeID}";
        }
    }
}