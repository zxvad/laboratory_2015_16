using System;
using System.Drawing;

namespace AirNavSystem
{
    class DataStorage : IImageStorage, IParametrsStorage
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

        public void StoreParams(params AlgorithmParams[] algorithmParams)
        {
            throw new NotImplementedException();
        }
    }
}