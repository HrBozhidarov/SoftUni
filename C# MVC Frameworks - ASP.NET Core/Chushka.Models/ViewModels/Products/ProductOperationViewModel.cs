using System.ComponentModel.DataAnnotations;

namespace Chushka.Models.ViewModels.Products
{
    public class ProductOperationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public string Price { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Range(1, 5, ErrorMessage = "Invalid product type")]
        public int ProductType { get; set; }

        public string DisableValue { get; set; } = "";

        public string Checked { get; set; } = "";

        public bool IsInDeleteUrl { get; set; }

        public bool IsInEditUrl { get; set; }
    }
}
