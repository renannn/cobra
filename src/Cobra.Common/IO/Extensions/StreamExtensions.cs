using System.IO;

namespace Cobra.Common.IO.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] GetAllBytes(this Stream stream)
        {
            byte[] array;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                array = memoryStream.ToArray();
            }
            return array;
        }
    }
}