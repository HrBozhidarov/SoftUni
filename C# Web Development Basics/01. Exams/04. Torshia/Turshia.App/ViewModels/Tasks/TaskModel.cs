using System;

namespace Turshia.App.ViewModels.Tasks
{
    public class TaskModel
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Sectors { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public int Level { get; set; }

        public string CustomerSector { get; set; }
        public string MarketingSector { get; set; }
        public string FinanceSector { get; set; }
        public string InternalSector { get; set; }
        public string ManagementSector { get; set; }
    }
}
