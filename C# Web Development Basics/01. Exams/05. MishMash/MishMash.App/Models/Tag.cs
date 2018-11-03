using System;
using System.Collections.Generic;
using System.Text;

namespace MishMash.App.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ChannelTag> Channels { get; set; } = new HashSet<ChannelTag>();
    }
}
