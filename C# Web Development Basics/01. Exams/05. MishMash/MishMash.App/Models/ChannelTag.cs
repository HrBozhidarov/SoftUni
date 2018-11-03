using System;
using System.Collections.Generic;
using System.Text;

namespace MishMash.App.Models
{
    public class ChannelTag
    {
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int ChannelId { get; set; }

        public Channel Channel { get; set; }
    }
}
