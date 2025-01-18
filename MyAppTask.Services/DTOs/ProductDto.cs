using System.ComponentModel.DataAnnotations;

namespace MyAppTask.Services;

public class ProductDto
{
   
    [Required(ErrorMessage = "Id is required for updating a product.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
    public string Name { get; set; }

    [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
    public int Quantity { get; set; }
    
    public decimal TotalValue { get; set; }
}