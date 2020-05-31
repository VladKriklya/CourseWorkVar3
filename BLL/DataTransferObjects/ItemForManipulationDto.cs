using System.ComponentModel.DataAnnotations;

namespace BLL.DataTransferObjects
{
    public abstract class ItemForManipulationDto
    {
        [Required(ErrorMessage = "Item name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Available Items is required and it can't be lower than 1")]
        public double Price { get; set; }
        [Required(ErrorMessage = "ImageURL is a required field.")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Sales is a required field.")]
        public int Sales { get; set; }
        [Range(1, 6, ErrorMessage = "Category is required")]
        public int Category { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Available Items is required and it can't be lower than 1")]
        public int AvailableItems { get; set; }
    }
}
