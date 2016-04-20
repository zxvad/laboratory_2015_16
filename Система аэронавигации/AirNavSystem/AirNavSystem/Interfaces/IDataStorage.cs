using System.Drawing;

namespace AirNavSystem
{
    interface IDataStorage
    {
        void StoreParams(params AlgorithmParams[] algorthmParams);
        AlgorithmParams[] LoadParams();
        void StoreImages(params Bitmap[] images);
        Bitmap[] LoadImages();
    }
}