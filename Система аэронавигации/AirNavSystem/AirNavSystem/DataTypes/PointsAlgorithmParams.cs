namespace AirNavSystem
{
    public class PointsAlgorithmParams : AlgorithmParams
    {
        public int SmallMedianFilterSize { get; set; }
        public int LargeMedianFilterSize { get; set; }

        public override string ToString()
        {
            return string.Format("{0}px {1}px", SmallMedianFilterSize, LargeMedianFilterSize);
        }
    }
}