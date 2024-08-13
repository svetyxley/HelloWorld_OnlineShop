using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Moq;
using NUnit.Framework;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data;
using OnlineShop.Entities;
using OnlineShop.Records;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace OnlineShop.Tests
{
    [TestFixture]
    public class SuppliersServiceTests
    {
        [Test]
        public void CheckGetById()
        {
            var context = new Mock<DapperContext>();
            context.Setup(x => x.OpenConnection(It.IsAny<string>()))
                .Returns(() => new SqlConnection());

            var logger = new Mock<ActivityLogService>();
            var service = new SuppliersService(context.Object, logger.Object, new OutputManager());

            var result = service.GetSupplierByID(1, "");

            context.Verify(x => x.OpenConnection(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CheckUpdateSupplier()
        {
            //Arrange
            var list = new List<Supplier>()
            {
                new Supplier(1, "name", "203894938"),
                new Supplier(10, "name", "203894938"),
                new Supplier(3, "name", "203894938"),
            };

            var id = 2;

            var context = new Mock<DapperContext>();
            context.Setup(x => x.OpenConnection(It.IsAny<string>()))
                .Returns(() => new SqlConnection());

            var logger = new Mock<ActivityLogService>();
            logger.Setup(x => x.OutputLog(It.IsAny<ActivityLog>()));

            var manager = new Mock<OutputManager>();
            manager.Setup(x => x.OutputToConsole(It.IsAny<string>(), It.IsAny<string>()));
            var service = new SuppliersService(context.Object, logger.Object, manager.Object);

            //Act
            var result = service.UpdateSupplier(list, id);

            //Assert
            Assert.IsNull(result);
            logger.Verify(x => x.OutputLog(It.IsAny<ActivityLog>()), Times.Once);
        }


        [Test]
        public void CheckUpdateSupplierReturnSupplier()
        {

            //Arrange
            var supplier = new Supplier(10, "supplier", "111111");

            var list = new List<Supplier>()
            {
                new Supplier(1, "name", "203894938"),
                supplier,
                new Supplier(3, "name", "203894938"),
            };

            var context = new Mock<DapperContext>();
            context.Setup(x => x.OpenConnection(It.IsAny<string>()))
                .Returns(() => new SqlConnection());

            var logger = new Mock<ActivityLogService>();
            logger.Setup(x => x.OutputLog(It.IsAny<ActivityLog>()));

            var manager = new Mock<OutputManager>();
            var service = new SuppliersService(context.Object, logger.Object, manager.Object);

            //Act
            var result = service.UpdateSupplier(list, supplier.SupplierID);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(supplier.SupplierID, result.SupplierID);
            Assert.AreEqual(supplier.SupplierName, result.SupplierName);
            Assert.AreEqual(supplier.SupplierEDRPOU, result.SupplierEDRPOU);
            logger.Verify(x => x.OutputLog(It.IsAny<ActivityLog>()), Times.Once);
        }
    }
}