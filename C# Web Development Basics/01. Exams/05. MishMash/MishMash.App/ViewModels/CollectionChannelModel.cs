using System.Collections.Generic;

namespace MishMash.App.ViewModels
{
    public class CollectionChannelModel
    {
        public IEnumerable<ChannelModel> YourChannels { get; set; } 

        public IEnumerable<ChannelModel> SuggestedChannels { get; set; }

        public IEnumerable<ChannelModel> SeeOtherChannels { get; set; }
    }
}
