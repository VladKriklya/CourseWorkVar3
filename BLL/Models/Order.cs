using BLL.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int UserForListId { get; set; }
        public UserForList User { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public DateTime Date { get; set; }
    }
}
