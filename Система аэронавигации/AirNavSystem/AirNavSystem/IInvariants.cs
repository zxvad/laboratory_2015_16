namespace AirNavSystem
{
    interface IInvariants
    {
        double[] Values { get; }
        double GetDistinctWith(Invariants other);
    }
}
