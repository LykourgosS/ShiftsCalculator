using System;

namespace ShiftsCalculator.Model
{
    internal class ShiftStructure
    {
        public int Index = -1;

        public string Name;

        public int NumberOfEmployees;

        public ShiftStructure(int id, string name, int numberOfEmployees)
        {
            Index = id;
            Name = name;
            NumberOfEmployees = numberOfEmployees;
        }
    }
}
