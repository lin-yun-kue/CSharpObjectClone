using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ObjectClone.Extension
{
    /// <summary>
    /// BinaryFormatter have security problem
    /// </summary>
    public static class BinaryFormatterClone
    {
        public static T DeepClone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", nameof(source));
            }

            if (source != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
            }

            return default(T);
        }
    }
}
