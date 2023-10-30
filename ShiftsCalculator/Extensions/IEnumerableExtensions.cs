using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftsCalculator.Extensions
{
    internal static class IEnumerableExtensions
    {
        public static bool IsLast<T>(this IEnumerable<T> enumerable, Func<T, bool> action)
        {
            var index = enumerable.ToList().FindIndex(x => action(x));
            return index >= 0 && index == enumerable.Count() - 1;
        }

        public static T? Next<T>(this IEnumerable<T> enumerable, Func<T, bool> action, bool whenLastGetFirst = false)
        {
            var index = enumerable.ToList().FindIndex(x => action(x));

            if (enumerable.IsLast(action))
            {
                if (whenLastGetFirst)
                {
                    return enumerable.First();
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return enumerable.ToList()[index + 1];
            }
        }
    }
}
