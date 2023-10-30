namespace LibraryStack.HolidayCalculator
{
    public static class GreekPublicHolidays
    {
        public static DateTime GetOrthodoxEaster(int year)
        {
            var a = year % 19;
            var b = year % 7;
            var c = year % 4;

            var d = (19 * a + 16) % 30;
            var e = (2 * c + 4 * b + 6 * d) % 7;
            var f = (19 * a + 16) % 30;

            var key = f + e + 3;
            var month = (key > 30) ? 5 : 4;
            var day = (key > 30) ? key - 30 : key;

            return new DateTime(year, month, day);
        }

        public static List<DateTime> GetHolidays(int year)
        {
            var easter = GetOrthodoxEaster(year);
            var holidays = new List<DateTime>
            {
                new DateTime(year, 1, 1),     //prwtoxronia
                new DateTime(year, 1, 6),     //fwta
                easter.AddDays(-48),          //kathara deytera
                new DateTime(year, 3, 25),    //25i martioy
                new DateTime(year, 5, 1),     //prwtomagia
                easter.AddDays(-2),           //megali paraskevi
                easter.AddDays(-1),           //megali savvato
                easter,                       //pasxa
                easter.AddDays(1),            //deyterh mera
                easter.AddDays(50),           //agiou pnevmatos
                new DateTime(year, 8, 15),    //koimisi theotokou
                new DateTime(year, 10, 28),   //28i oktovriou
                new DateTime(year, 12, 25),   //xristougenna
                new DateTime(year, 12, 26)   //deyterh mera
            };

            return holidays;
        }

        public static bool IsHoliday(DateTime date)
        {
            return GetHolidays(date.Year).Contains(date);
        }

        public static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}