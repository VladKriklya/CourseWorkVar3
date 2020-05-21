using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
