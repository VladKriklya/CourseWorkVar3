using BLL.Models;
using BLL.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DataTransferObjects
{
    public abstract class OrderForManipulationDto
    {
        [Required(ErrorMessage = "UserForListId is a required field.")]
        public int UserForListId { get; set; }
        [Required(ErrorMessage = "User is a required field.")]
        public UserForList User { get; set; }
        [Required(ErrorMessage = "User is a required field.")]
        public IEnumerable<Item> Items { get; set; }
        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }
    }
}
