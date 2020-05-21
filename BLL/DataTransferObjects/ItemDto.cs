using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Sales { get; set; }
        public int Category { get; set; }
        public int AvailableItems { get; set; }
    }
}
