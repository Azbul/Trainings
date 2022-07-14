namespace MyPhotoshop
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        public PixelFilter(IParameters parameters) : base(parameters) { }

        public abstract Pixel ProccessPixel(Pixel pixel, IParameters parameters);

        public override Photo Proccess(Photo original, IParameters parameters)
        {
            var result = new Photo(original.width, original.height);

            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                    result[x, y] = ProccessPixel(original[x, y], parameters);

            return result;
        }
    }
}
