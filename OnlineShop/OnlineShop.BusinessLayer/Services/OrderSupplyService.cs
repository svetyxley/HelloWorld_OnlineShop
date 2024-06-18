using OnlineShop.Entities;
using OnlineShop.Constants;

namespace OnlineShop.EntityServices
{
    public class OrderSupplyService
    {
        private InputManager inputManager = new();
        private OutputManager outputManager = new();
        private IDGenerator idGenerator = new();
        private InputValidator inputValidator = new();
        private CommonEntityService<OrderSupply> commonEntityService = new();
        private SuppliersService suppliersService = new();
        private ProductsService productsService = new();
        private EmployeeService employeeService = new();



        private List<OrderSupply> orderSupply = new List<OrderSupply>()
        {
            new OrderSupply(1, 15, DateTime.Now.ToString()),
            new OrderSupply(2, 8, DateTime.Now.ToString()),
            new OrderSupply(3, 18, DateTime.Now.ToString()),
        };
        public OrderSupply MakeOrderOfSupply()
        {
            int supplyID = idGenerator.InputID(orderSupply);
            int productAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
            string orderTime = DateTime.Now.ToString();
            return new OrderSupply(supplyID, suppliersService.GetSupplierByID(), productsService.GetProductByID(), productAmount, orderTime, employeeService.GetEmployeeByID());
        }
        public void AddOrder()
        {
            orderSupply.Add(MakeOrderOfSupply());
            outputManager.Write(NotificationConstants.ORDERED, commonEntityService.GetListType());
        }
        public OrderSupply GetSupplyOrderByID()
        {
            var supplyID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var supply = orderSupply.FirstOrDefault(orderSupply => orderSupply.SupplyOrderID == supplyID);
            if (supply == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.Write(supply.ToString(), commonEntityService.GetListType());
            }
            return supply;
        }
        public int GetAmount()
        {
            var supplyAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
            var supply = orderSupply.FirstOrDefault(orderSupply => orderSupply.ProductAmount == supplyAmount);
            if (supply == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.Write(supply.ToString(), commonEntityService.GetListType());
            }
            return supplyAmount;
        }
        public void OutputSupplyOrders()
        {
            outputManager.Write(commonEntityService.OutputList(orderSupply), commonEntityService.GetListType());
        }
    }
}