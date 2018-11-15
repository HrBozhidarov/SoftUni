using Chushka.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Chushka.Models.ViewModels.Products
{
    public class ProductHomeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 5, ErrorMessage = "Invalid product type")]
        public ProductType ProductType { get; set; }

        public string RestrictDescription
        {
            get
            {
                if (this.Description == null || Description.Length <= 50)
                {
                    return this.Description;
                }

                return this.Description.Substring(0, 50) + "...";
            }
        }
    }
}
