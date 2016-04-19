namespace AirNavSystem
{
    public class ContoursAlgorithmParams
    {
        public int MedianFilterSize { get; set; }
        public int Threshold { get; set; }

        public override string ToString()
        {
            return string.Format("{0}px {1}", MedianFilterSize, Threshold);
        }
    }
}