using DAL.Data.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class OrderControllerTests
    {
        public int count = 0;

        [Fact]
        public async Task OrderPost()
        {
            /*var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.CreateOrder(null))
                .Returns(Increase());
            var mockManager = new Mock<IRepositoryManager>();
            mockManager.Setup(manager => manager.Orders)
                .Returns(orderRepository.Object);


    */

        }

        public void Increase()
        {
            count++;
        }

    }
}