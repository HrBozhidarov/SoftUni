
using System.Collections.Generic;
using System.Text;

namespace MishMash.App.Models
{
    public class Channel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }

        public ICollection<ChannelTag> ChannelTags { get; set; } = new HashSet<ChannelTag>();

        public ICollection<UserChannel> Followers { get; set; } = new HashSet<UserChannel>();
    }
}
