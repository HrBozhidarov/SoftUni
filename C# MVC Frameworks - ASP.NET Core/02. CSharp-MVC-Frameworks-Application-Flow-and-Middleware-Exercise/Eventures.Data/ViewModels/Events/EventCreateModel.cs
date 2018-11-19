using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Data.ViewModels.Events
{
    public class EventCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Range(1,int.MaxValue)]
        public int TotalTickets { get; set; }

        [Range(1, double.MaxValue)]
        public decimal PricePerTicket { get; set; }
    }
}
