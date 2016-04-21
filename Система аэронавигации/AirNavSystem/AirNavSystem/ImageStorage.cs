using System;
using System.Drawing;

namespace AirNavSystem
{
    public class ImageStorage : IDataStorage<Bitmap>
    {
        public Bitmap[] Load()
        {
            throw new NotImplementedException();
        }

        public void Store(params Bitmap[] objects)
        {
            throw new NotImplementedException();
        }
    }
}