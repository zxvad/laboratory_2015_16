namespace AirNavSystem
{
    interface IStorage<T>
    {
        T[] Load();
        void Store(params T[] images);
    }
}