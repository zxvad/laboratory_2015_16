using System;
using System.Drawing;

namespace AirNavSystem
{
    class DataStorage : IDataStorage<Bitmap>,IDataStorage<AlgorithmParams>
    {
        ImageStorage imageStoage;
        ParametrsStorage parametrsStorage;

        AlgorithmParams[] IDataStorage<AlgorithmParams>.Load()
        {
            return parametrsStorage.Load();
        }

        Bitmap[] IDataStorage<Bitmap>.Load()
        {
            return imageStoage.Load();
        }

        void IDataStorage<AlgorithmParams>.Store(params AlgorithmParams[] objects)
        {
            parametrsStorage.Store(objects);
        }

        void IDataStorage<Bitmap>.Store(params Bitmap[] objects)
        {
            imageStoage.Store(objects);
        }
    }
}