using System;
using System.Collections.Generic;
using System.Text;

namespace Turshia.App.Models
{
    public class TaskSector
    {
        public int SectorId { get; set; }

        public Sector Sector { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
