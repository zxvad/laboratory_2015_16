namespace AirNavSystem
{
    interface IDataStorage<T>
    {
        T[] Load();
        void Store(params T[] objects);
    }
}