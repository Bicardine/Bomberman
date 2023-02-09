using System;

namespace Bomberman.Utils
{
    public static class EnumUtils
    {
        public static T GetRandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        }
    }
}