using System;
using System.Collections.Generic;
using System.Text;

namespace MishMash.App.ViewModels
{
    public class ChannelModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string ChannelType { get; set; }

        public int FollewrsCoun { get; set; }
    }
}
