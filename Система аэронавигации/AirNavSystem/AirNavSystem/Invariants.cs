using System;

namespace AirNavSystem
{
    class Invariants : IPointDetector<Invariants>
    {
        public double[] Values { get; }

        public Invariants()
        {
            Values = new double[7];
        }

        public double GetDistinctWith(Invariants other)
        {
            double distinct = 0;
            for (int i = 0; i < Values.Length; ++i)
                distinct += Math.Pow(Values[i] - other.Values[i], 2);
            return distinct;
        }
    }
}
