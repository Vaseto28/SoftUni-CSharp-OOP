
namespace T01.ClassBoxData
{
    using System;

    public class Box
    {
        private const int BoxDimentionsMinValue = 0;

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
                if (value <= BoxDimentionsMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
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
                if (value <= BoxDimentionsMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
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
                if (value <= BoxDimentionsMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
            => 2 * ((this.Length * this.Width) + (this.Length * this.Height) + (this.Width * this.Height));

        public double LateralSurfaceArea()
            => 2 * ((this.Length * this.Height) + (this.Width * this.Height));

        public double Volume()
            => this.Width * this.Height * this.Length;

        public override string ToString()
            => $"Surface Area - {this.SurfaceArea():f2}{Environment.NewLine}Lateral Surface Area - {this.LateralSurfaceArea():f2}{Environment.NewLine}Volume - {this.Volume():f2}";
    }
}