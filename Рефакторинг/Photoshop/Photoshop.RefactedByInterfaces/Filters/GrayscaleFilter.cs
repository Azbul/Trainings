namespace MyPhotoshop
{
	public class GrayscaleFilter : PixelFilter
	{
		public GrayscaleFilter() : base(new EmptyParameters()) { }
		
		public override string ToString ()
		{
			return "Оттенки серого";
		}

        public override Pixel ProccessPixel(Pixel pixel, IParameters parameters)
        {
            var lightness = pixel.R + pixel.G + pixel.B;
            lightness = lightness / 3;
            return new Pixel(lightness, lightness, lightness);
        }
	}
}

