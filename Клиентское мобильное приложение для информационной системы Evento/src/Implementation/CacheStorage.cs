using System.IO;
using System.Security.Cryptography;
using System.Text;
using Evento.Client.Core;
using Tolltech.SOACore.Common;

namespace Evento.Client.Implementation
{
    public class CacheStorage : ICacheStorage
    {
        private const string CachePathName = "cache";
        private readonly ISerialier serializer;

        public CacheStorage(ISerialier serializer)
        {
            this.serializer = serializer;
        }

        public void ResetCache()
        {
            if (Directory.Exists(CachePathName))
            {
                Directory.Delete(CachePathName);
            }
        }

        public T Get<T>(byte[] objectHash)
        {
            var cacheFileName = Encoding.UTF8.GetString(objectHash);

            return File.Exists(cacheFileName) 
                ? serializer.Deserialize<T>(File.ReadAllBytes(cacheFileName)) 
                : default(T);
        }

        public bool Store<T>(T obj)
        {
            var bytes = serializer.Serialize(obj);
            var cacheFileName = Encoding.UTF8.GetString(MD5.Create().ComputeHash(bytes, 0, bytes.Length));

            try
            {
                File.WriteAllBytes(Path.Combine(CachePathName, cacheFileName), bytes);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}