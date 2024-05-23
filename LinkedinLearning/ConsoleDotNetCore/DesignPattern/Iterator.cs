using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.DesignPattern
{
    public class Iterator
    {
        public void Run()
        {
            var collection = new DasyMonthCollection();
            foreach (var monthWithDays in collection)
            {
                Console.WriteLine($"Days in {monthWithDays.Date} - {monthWithDays.Days}");
            }
        }
    }

    class MonthWithDays
    {
        public string Date { get; set; }
        public int Days { get; set; }
    }

    class DaysInMonthEnumerator : IEnumerator<MonthWithDays>
    {
        private int year = 1;
        private int month = 0;

        public MonthWithDays Current => new MonthWithDays()
        {
            Date = $"{year.ToString().PadLeft(4, '0')}-{month}",
            Days = DateTime.DaysInMonth(year, month)
        };

        object IEnumerator.Current => Current;

        public void Dispose()
        {            
        }

        public bool MoveNext()
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            return year < 5;
        }

        public void Reset()
        {
            month = 0;
            year = 1;
        }
    }

    class DasyMonthCollection : IEnumerable<MonthWithDays>
    {
        public IEnumerator<MonthWithDays> GetEnumerator()
        {
            return new DaysInMonthEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
