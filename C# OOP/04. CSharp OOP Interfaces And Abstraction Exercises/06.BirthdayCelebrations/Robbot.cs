﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public class Robbot : IRobbot
    {
        public Robbot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get;
            private set;
        }

        public string Id
        {
            get;
            private set;
        }
    }
}
