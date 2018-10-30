using System;
using System.Collections.Generic;
using System.Text;

namespace MeTube.App.Models
{
    public class Tube
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string YouTubeId { get; set; }

        public string YoutubeLink { get; set; }

        public int Views { get; set; }

        public int UploderId { get; set; }

        public User Uploder { get; set; }
    }
}
