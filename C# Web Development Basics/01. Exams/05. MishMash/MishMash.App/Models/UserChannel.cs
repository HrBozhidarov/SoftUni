using System;
using System.Collections.Generic;
using System.Text;

namespace MishMash.App.Models
{
    public class UserChannel
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ChannelId { get; set; }

        public Channel Channel { get; set; }
    }
}
