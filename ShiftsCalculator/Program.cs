using ShiftsCalculator.Model;
using ShiftsCalculator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftsCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = GetEmployees(44);

            var structures = new List<DayStructure>()
            {
                new DayStructure(DayOfWeek.Monday, new List<ShiftStructure>() { new ShiftStructure(0,$"{DayOfWeek.Sunday} 20:30 - 08:30", 2) }),
                new DayStructure(DayOfWeek.Tuesday, new List<ShiftStructure>() { new ShiftStructure(0, $"{DayOfWeek.Monday} 20:30 - 08:30", 2) }),
                new DayStructure(DayOfWeek.Wednesday, new List<ShiftStructure>() { new ShiftStructure(0, $"{DayOfWeek.Tuesday} 20:30 - 08:30", 2) }),
                new DayStructure(DayOfWeek.Thursday, new List<ShiftStructure>() { new ShiftStructure(0, $"{DayOfWeek.Wednesday} 20:30 - 08:30", 2) }),
                new DayStructure(DayOfWeek.Friday, new List<ShiftStructure>() { new ShiftStructure(0, $"{DayOfWeek.Thursday} 20:30 - 08:30", 2) }),
                new DayStructure(DayOfWeek.Saturday, new List<ShiftStructure>() { new ShiftStructure(0, $"{DayOfWeek.Friday} 20:30 - 14:30", 2), new ShiftStructure(1, $"{DayOfWeek.Saturday} 14:30 - 08:30", 2) }),
                new DayStructure(DayOfWeek.Sunday, new List<ShiftStructure>() { new ShiftStructure(0, $"{DayOfWeek.Sunday} 08:30 - 20:30", 2) }),
            };

            var shift = new Shift(new DateTime(2023, 10, 2), structures[0].ShiftStructures[0], new List<int> { 28, 29 });

            var calculator = new ShiftCalculator(employees, shift, structures);

            //calculator.GetShiftsFor(1, DateTime.Today.AddMonths(3)).ToList().ForEach(x=> Console.WriteLine(x.ToString()));
            calculator.GetShifts(DateTime.Today.AddMonths(3)).ToList().ForEach(x=> Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        public static IEnumerable<int> GetEmployees(int lastEmployee, params int[] missingEmployees)
        {
            var employees = Enumerable.Range(1, lastEmployee);
            return employees.Except(missingEmployees);
        }
    }
}