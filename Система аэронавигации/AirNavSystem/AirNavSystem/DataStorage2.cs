using System;
using System.Drawing;

namespace AirNavSystem
{
    class DataStorage2 : IDataStorage<Bitmap>, IDataStorage<AlgorithmParams>
    {
        AlgorithmParams[] IDataStorage<AlgorithmParams>.Load()
        {
            throw new NotImplementedException();
        }

        Bitmap[] IDataStorage<Bitmap>.Load()
        {
            throw new NotImplementedException();
        }

        void IDataStorage<AlgorithmParams>.Store(params AlgorithmParams[] data)
        {
            throw new NotImplementedException();
        }

        void IDataStorage<Bitmap>.Store(params Bitmap[] data)
        {
            throw new NotImplementedException();
        }
    }
}
