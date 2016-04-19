namespace AirNavSystem
{
    interface IPointDescriptor<T>
    {
        double [] Values { get; }
        double GetDistinctWith(T other);
    }
}
