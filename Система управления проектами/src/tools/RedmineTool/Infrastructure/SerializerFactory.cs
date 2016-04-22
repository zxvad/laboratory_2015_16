using System;
using RedmineTool.Interfaces;

namespace RedmineTool.Infrastructure
{
    public static class SerializerFactory
    {
        public static ISerializer Get(string format)
        {
            if (format == ApiFormats.Json)
            {
                return new Serializers.JsonSerializer();
            }

            throw new NotSupportedException("Serializer not supported");
        }
    }
}