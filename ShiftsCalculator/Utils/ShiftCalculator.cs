using LibraryStack.HolidayCalculator;
using ShiftsCalculator.Extensions;
using ShiftsCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftsCalculator.Utils
{
    internal class ShiftCalculator
    {
        public IEnumerable<int> Employees;

        public Shift KnownShift;

        public IEnumerable<DayStructure> Structures;

        public ShiftCalculator(IEnumerable<int> employees, Shift knownShift, IEnumerable<DayStructure> structures)
        {
            Employees = employees;
            KnownShift = knownShift;
            Structures = structures.OrderByDescending(x => x.Date);
        }

        public List<int> GetNextEmployees(Shift shift, int numberOfEmployees)
        {
            var nextEmployees = new List<int>();

            //var lastEmployee = Employees.ToList().FindIndex(x => x == shift.Employees.Last());
            var lastEmployee = shift.Employees.Last();
            while (nextEmployees.Count() < numberOfEmployees)
            {
                nextEmployees.Add(Employees.Next(x => x == lastEmployee, true));
                lastEmployee = nextEmployees.Last();
            }

            return nextEmployees;
        }

        public DayStructure GetDayStructure(Shift shift)
        {
            return Structures.First(x => x.AppliesTo(shift.Date));
        }

        public Shift GetNextShift(Shift shift)
        {
            var date = shift.Date;
            var dayStructure = GetDayStructure(shift);
            var shiftStructure = dayStructure.GetNextShiftStructure(shift.Structure.Index);

            if (dayStructure.IsLastShiftOfTheDay(shift.Structure.Index))
            {
                date = GreekPublicHolidays.GetInstance().IsWorkDay(shift.Date) ? shift.Date.GetNextWorkday() : shift.Date.GetNextHoliday();
                dayStructure = Structures.First(x => x.AppliesTo(date));
                shiftStructure = dayStructure.GetFirstShiftStructure();
            }

            var employees = GetNextEmployees(shift, shiftStructure.NumberOfEmployees);

            return new Shift(date, shiftStructure, employees);
        }

        public IEnumerable<Shift> GetShifts(DateTime dateTo)
        {
            var shifts = new List<Shift>() { KnownShift };
            while (shifts.Last().Date <= dateTo)
            {
                shifts.Add(GetNextShift(shifts.Last()));

            }
            return shifts;
        }

        public IEnumerable<Shift> GetShiftsFor(int employee, DateTime dateTo)
        {
            var shifts = GetShifts(dateTo);
            return shifts.Where(x => x.Employees.Contains(employee));
        }
    }
}
