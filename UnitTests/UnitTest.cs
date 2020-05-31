using BLL.DataTransferObjects;
using BLL.Models;
using BLL.RequestFeatures;
using BLL.RequestParameters;
using BLL.UserModels;
using DAL.Data;
using DAL.Data.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIL.Controllers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void OrderControllerPostMethodReturnNullValueTest()
        {
            //Arrange
            var orderTemp = new OrderForCreationDto();
            var order = new Order();
            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.CreateOrder(order));
            var mockManager = new Mock<IRepositoryManager>();
            mockManager.Setup(manager => manager.Orders).Returns(orderRepository.Object);
            OrderController controller = new OrderController(mockManager.Object, null, null);

            //Act
            Order result = controller.PostItem(orderTemp).Result.Value;

            //Assert
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void ItemControllerGetAllItemsMethodTest()
        {
            //Arrange
            var param = new ItemParameters();
            var itemRepository = new Mock<IItemRepository>();
            itemRepository.Setup(repo => repo.GetAllItemsAsync(param, false)).Returns(getList());
            var mockManager = new Mock<IRepositoryManager>();
            mockManager.Setup(manager => manager.Items).Returns(itemRepository.Object);
            ItemController controller = new ItemController(mockManager.Object, null, null);

            //Act
            var list = controller.GetItems(param).Result;

            //Assert
            Assert.AreEqual(list, getList());
        }

        [TestMethod]
        public void ItemControllerGetItemMethodTest()
        {
            //Arrange
            var item = new Item();
            var itemRepository = new Mock<IItemRepository>();
            itemRepository.Setup(repo => repo.GetItemAsync(item.Id, false)).Returns(new Task<Item>(() => item));
            var mockManager = new Mock<IRepositoryManager>();
            mockManager.Setup(manager => manager.Items).Returns(itemRepository.Object);
            ItemController controller = new ItemController(mockManager.Object, null, null);

            //Act
            var res = controller.GetItem(item.Id).Result;

            //Assert
            Assert.AreEqual(res, item);
        }

        [TestMethod]
        public void ItemControllerPostItemMethodTest()
        {
            //Arrange
            var item = new Item();
            var itemDto = new ItemForCreationDto();
            var itemRepository = new Mock<IItemRepository>();
            itemRepository.Setup(repo => repo.CreateItem(item));
            var mockManager = new Mock<IRepositoryManager>();
            mockManager.Setup(manager => manager.Items).Returns(itemRepository.Object);
            ItemController controller = new ItemController(mockManager.Object, null, null);

            //Act
            var res = controller.PostItem(itemDto).Result;

            //Assert
            Assert.AreEqual(res, item);
        }


        private static Task<PagedList<Item>> getList()
        {
            List<Item> list = new List<Item>();
            list.Add(new Item());
            PagedList<Item> plist = new PagedList<Item>(list, 1, 4, 8);
            return new Task<PagedList<Item>>(() => plist);
        }

    }
}
