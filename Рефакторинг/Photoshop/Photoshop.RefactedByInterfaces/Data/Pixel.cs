using System;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b)
        {
            this = new Pixel
            {
                R = r,
                G = g,
                B = b
            };
        }

        double Check(double val)
        {
            if (val < 0 || val> 1) throw new ArgumentException();
            return val;
        }

        double _r;

        public double R
        {
            get { return _r; }

            set { _r = Check(value);  }
        }

        double _g;

        public double G
        {
            get { return _g; }

            set { _g = Check(value); }
        }

        double _b;

        public double B
        {
            get { return _b; }

            set { _b = Check(value); }
        }

        public static double Trim(double val)
        {
            if (val > 1) return 1;
            if (val < 0) return 0;
            return val;
        }

        public static Pixel operator*(Pixel pixel, double val)
        {
            return new Pixel(
                    Trim(pixel.R * val),
                    Trim(pixel.G * val),
                    Trim(pixel.B * val)
                    );
        }

        public static Pixel operator*(double val, Pixel pixel)
        {
            return pixel * val;
        }
    }
}
