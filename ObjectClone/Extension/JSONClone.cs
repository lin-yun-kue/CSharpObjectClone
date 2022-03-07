using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ObjectClone.Extension
{
    public static class JSONClone
    {
        public static T DeepCloneByJson<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            var jsonString = JsonSerializer.Serialize(source);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
