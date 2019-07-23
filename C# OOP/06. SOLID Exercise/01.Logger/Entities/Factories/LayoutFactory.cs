using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout": return new SimpleLayout();
                case "XmlLayout": return new XmlLayout();
                default: throw new ArgumentException($"This layout type [{layoutType}] does`t exists.");
            }
        }
    }
}
