using System;
using System.Collections.Generic;
using System.Text;

namespace Turshia.App.Models
{
    public class Report
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }

        public int ReporterId { get; set; }

        public User Reporter { get; set; }
    }
}
