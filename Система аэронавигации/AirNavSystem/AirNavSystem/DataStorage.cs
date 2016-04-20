using System;
using System.Drawing;

namespace AirNavSystem
{
    class DataStorage : IDataStorage
    {
        ImageStorage imageStoage;
        ParametrsStorage parametrsStorage;

        public Bitmap[] LoadImages()
        {
            throw new NotImplementedException();
        }

        public AlgorithmParams[] LoadParams()
        {
            throw new NotImplementedException();
        }

        public void StoreImages(params Bitmap[] images)
        {
            throw new NotImplementedException();
        }

        public void StoreParams(params AlgorithmParams[] algorthmParams)
        {
            throw new NotImplementedException();
        }
    }
}