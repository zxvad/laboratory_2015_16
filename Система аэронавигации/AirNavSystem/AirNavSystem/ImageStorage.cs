using System;
using System.Drawing;

namespace AirNavSystem
{
    public class ImageStorage : IStorage<Bitmap>
    {
        public Bitmap[] Load()
        {
            throw new NotImplementedException();
        }

        public void Store(params Bitmap[] images)
        {
            throw new NotImplementedException();
        }
    }
}