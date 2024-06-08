using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel
    {
        public string AreaIdText { get; set; } = string.Empty;
        public string DataDateText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;
    }
}
