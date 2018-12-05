using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Data.ViewModels.Events
{
    public class EventCreateModel
    {
        [Required]
        [RegularExpression(@"\S{10,}",ErrorMessage = "The name must be at least 10 symbols, without spaces.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "Place have to be long at least 1 symbol, without spaces.")]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Range(1,int.MaxValue)]
        public int TotalTickets { get; set; }

        [Range(typeof(decimal), "1", "79228162514264337593543950335")]
        public decimal PricePerTicket { get; set; }
    }
}
