using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class LinqTips
    {
        public void Run()
        {
            
        }

        public void SelectCalender()
        {
            var calenders = new List<HistoryCalender>();

            var cal = new HistoryCalender();
            cal.Decade = "Seventies";
            cal.Years = Enumerable.Range(1970, 10).ToList();
            calenders.Add(cal);

            cal = new HistoryCalender();
            cal.Decade = "Eighties";
            cal.Years = Enumerable.Range(1980, 10).ToList();
            calenders.Add(cal);

            var selectResult = calenders.Select(m => m);
            var manyResult = calenders.SelectMany(m => m.Years);
        }

        public class HistoryCalender
        {
            public string Decade { get; set; }
            public List<int> Years { get; set; }
        }
    }
}
