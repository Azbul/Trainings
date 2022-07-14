namespace MyPhotoshop
{
    public class EmptyParameters : IParameters
    {
        public double Coefficient { get; set; }

        public ParameterInfo[] GetDesсription()
        {
            return new ParameterInfo[0];
        }

        public void SetValues(double[] values)
        {
        
        }
    }
}
