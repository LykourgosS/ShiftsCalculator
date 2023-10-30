using System;
using System.Collections.Generic;

namespace ShiftsCalculator.Model
{
    internal class Shift
    {
        public DateTime Date;

        public ShiftStructure Structure;

        public IEnumerable<int> Employees;

        public Shift(DateTime date, ShiftStructure structure, IEnumerable<int> employees)
        {
            Date = date;
            Structure = structure;
            Employees = employees;
        }

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()} - Index: {Structure.Name} - Employees: [{string.Join(", ", Employees)}]";
        }
    }
}
