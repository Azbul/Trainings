namespace MyPhotoshop
{
    public abstract class ParametrizedFilter : IFilter
    {
        private IParameters parameters;

        public ParametrizedFilter(IParameters parameters)
        {
            this.parameters = parameters;
        }

        public ParameterInfo[] GetParameters()
        {
            return parameters.GetDesсription();
        }

        public Photo Process(Photo original, double[] values)
        {
            parameters.SetValues(values);
            return Proccess(original, parameters);
        }

        public abstract Photo Proccess(Photo original, IParameters parameters);
    }
}
