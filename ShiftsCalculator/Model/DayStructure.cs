using LibraryStack.HolidayCalculator;
using ShiftsCalculator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftsCalculator.Model
{
    internal class DayStructure
    {
        public DateTime Date;

        public DayOfWeek DayOfWeek;

        public List<ShiftStructure> ShiftStructures;

        public DayStructure(DateTime date, List<ShiftStructure> shiftStructures)
        {
            Date = date;
            ShiftStructures = shiftStructures;
        }

        public DayStructure(DayOfWeek dayOfWeek, List<ShiftStructure> shiftStructures)
        {
            DayOfWeek = dayOfWeek;
            ShiftStructures = shiftStructures;
        }

        public bool AppliesTo(DateTime dateToCheck)
        {
            if (Date == DateTime.MinValue)
            {
                return dateToCheck.DayOfWeek == DayOfWeek;
            }
            else
            {
                if (GreekPublicHolidays.IsWorkDay(Date))
                {
                    return dateToCheck.Day == Date.Day && dateToCheck.Month == Date.Month;
                }
                else
                {
                    return dateToCheck == Date;
                }
            }
        }

        public bool IsLastShiftOfTheDay(int index)
        {
            return ShiftStructures.IsLast(x => x.Index == index);
        }

        public ShiftStructure? GetFirstShiftStructure()
        {
            return ShiftStructures.FirstOrDefault();
        }

        public ShiftStructure? GetNextShiftStructure(int index)
        {
            if (index < 0)
            {
                return GetFirstShiftStructure();
            }
            else
            {
                if (IsLastShiftOfTheDay(index))
                {
                    return null;
                }
                else
                {
                    return ShiftStructures.Next(x => x.Index == index);
                }
            }
        }
    }
}
