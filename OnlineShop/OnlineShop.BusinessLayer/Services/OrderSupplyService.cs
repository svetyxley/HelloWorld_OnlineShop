using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Constants;
using OnlineShop.EntityServices;
using OnlineShop.Records;

namespace OnlineShop.BusinessLayer.Services
{
    public class OrderSupplyService
    {
        private InputManager inputManager = new();
        private OutputManager outputManager = new();
        private IDGenerator idGenerator = new();
        private InputValidator inputValidator = new();
        private CommonEntityService<OrderSupply> commonEntityService = new();
        private SuppliersService suppliersService = new(new DapperContext(), new ActivityLogService(), new OutputManager());
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
            return new OrderSupply(supplyID, suppliersService.GetSupplierByID(1, "connectionString"), productsService.GetProductByID(), productAmount, orderTime, employeeService.GetEmployeeByID());
        }
        public void AddOrder()
        {
            orderSupply.Add(MakeOrderOfSupply());
            outputManager.OutputToConsole(NotificationConstants.ORDERED, commonEntityService.GetListType());
        }
        public OrderSupply GetSupplyOrderByID()
        {
            var supplyID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var supply = orderSupply.FirstOrDefault(orderSupply => orderSupply.SupplyOrderID == supplyID);
            if (supply == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.OutputToConsole(supply.ToString(), commonEntityService.GetListType());
            }
            return supply;
        }
        public int GetAmount()
        {
            var supplyAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
            var supply = orderSupply.FirstOrDefault(orderSupply => orderSupply.ProductAmount == supplyAmount);
            if (supply == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.OutputToConsole(supply.ToString(), commonEntityService.GetListType());
            }
            return supplyAmount;
        }
        public void OutputSupplyOrders()
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(orderSupply), commonEntityService.GetListType());
        }
    }
}