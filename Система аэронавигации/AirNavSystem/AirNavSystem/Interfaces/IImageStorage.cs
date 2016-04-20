using System.Drawing;

namespace AirNavSystem
{
    public interface IImageStorage
    {
        Bitmap[] LoadImages();
        void StoreImages(params Bitmap[] images);
    }
}