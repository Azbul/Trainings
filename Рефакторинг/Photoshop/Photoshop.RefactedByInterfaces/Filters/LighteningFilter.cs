namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter
	{
        public LighteningFilter() : base(new LighteningParameters()) { }
        
		public override string ToString ()
		{
			return "Осветление/затемнение";
		}
		
        public override Pixel ProccessPixel(Pixel pixel, IParameters parameters)
        {
            return pixel * (parameters as LighteningParameters).Coefficient; //downcast чтобы здесь получить Coefficient
        }
    }
}

