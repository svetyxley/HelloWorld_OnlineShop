using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Constants;
using OnlineShop.EntityServices;

namespace OnlineShop.BusinessLayer.Services
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
        private List<OrderSupply> orderSupply = new List<OrderSupply>();

        public async Task<OrderSupply> MakeOrderOfSupply(int supplyID, int productAmount, DateTime orderTime)
        {
            //int supplyID = idGenerator.InputID(orderSupply);
            //int productAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
            //string orderTime = DateTime.Now.ToString();
            try
            {
                return new OrderSupply(supplyID, await suppliersService.GetSupplierByID(1, "connectionString"), await productsService.GetProductByID(1, "connectionString"), productAmount, orderTime, employeeService.GetEmployeeByID());
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        //public async Task AddOrder(int supplyID, int productAmount, DateTime orderTime)
        //{
        //    orderSupply.Add(await MakeOrderOfSupply(supplyID, productAmount, orderTime));
        //    outputManager.OutputToConsole(NotificationConstants.SUPPLY_IS_SUCESSFULLY_ORDERED, commonEntityService.GetListType());
        //}
        public async Task<OrderSupply> GetSupplyOrderByID(int supplyID)
        {
            //var supplyID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            try
            {
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
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task<int> GetAmount(int supplyAmount)
        {
            //var supplyAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
            try
            {
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
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task OutputSupplyOrders()
        {
            try
            {
                outputManager.OutputToConsole(commonEntityService.OutputList(orderSupply), commonEntityService.GetListType());
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
    }
}