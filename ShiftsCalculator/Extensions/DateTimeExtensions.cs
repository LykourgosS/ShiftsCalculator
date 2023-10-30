using LibraryStack.HolidayCalculator;
using System;

namespace ShiftsCalculator.Extensions
{
    static class DateTimeExtensions
    {
        private static DateTime GetNextDay(this DateTime date, Func<DateTime, bool> action)
        {
            var nextDay = date.AddDays(1);
            while (true)
            {
                if (action(nextDay))
                {
                    return nextDay;
                }
                else
                {
                    nextDay = nextDay.AddDays(1);
                }
            }
        }

        public static DateTime GetNextHoliday(this DateTime date)
        {
            return date.GetNextDay(x => !GreekPublicHolidays.IsWorkDay(x));
        }

        public static DateTime GetNextWorkday(this DateTime date)
        {
            return date.GetNextDay(x => GreekPublicHolidays.IsWorkDay(x));
        }
    }
}
