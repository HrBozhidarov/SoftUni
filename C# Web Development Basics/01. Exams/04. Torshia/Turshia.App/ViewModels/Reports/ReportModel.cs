using System;
using System.Collections.Generic;
using System.Text;

namespace Turshia.App.ViewModels.Reports
{
    public class ReportModel
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public int Level { get; set; }

        public string Status { get; set; }

        public string DueDate { get; set; }

        public string ReportedOn { get; set; }

        public string ReporterName { get; set; }

        public string Participants { get; set; }

        public string AffectedSectors { get; set; }

        public string TaskDescription { get; set; }
    }
}
