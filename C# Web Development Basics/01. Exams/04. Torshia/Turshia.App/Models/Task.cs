using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace Turshia.App.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public ICollection<TaskSector> AffectedSectors { get; set; } = new HashSet<TaskSector>();
    }
}
