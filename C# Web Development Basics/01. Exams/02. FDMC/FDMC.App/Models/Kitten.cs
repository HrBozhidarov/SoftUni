using System;
using System.Collections.Generic;
using System.Text;

namespace FDMC.App.Models
{
    public class Kitten
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public BreedType Breed { get; set; }
    }
}
