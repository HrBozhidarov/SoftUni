using System;
using System.Collections.Generic;
using System.Text;

namespace _01.BoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                CheckIfNumberIsNegative(value, "Length");

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                CheckIfNumberIsNegative(value, "Width");

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                CheckIfNumberIsNegative(value, "Height");

                this.height = value;
            }
        }

        private void CheckIfNumberIsNegative(double num, string propertyName)
        {
            if (num <= 0)
            {
                throw new InvalidOperationException($"{propertyName} cannot be zero or negative.");
            }
        }


        public double SurfaceArea()
        {
            return (2 * this.length * this.width) + this.LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return (2 * this.length * this.height) + (2 * this.height * this.width);
        }

        public double Volume()
        {
            return this.length * this.width * this.height;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea().ToString("F2")}\nLateral Surface Area - {this.LateralSurfaceArea().ToString("F2")}\nVolume - {this.Volume().ToString("F2")}";
        }
    }
}
