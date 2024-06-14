using DDD.Domain.Repositoriers;
using DDD.WinForm.Common;
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
        private IWeatherRepository weather;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="weather"></param>
        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            this.weather = weather;
        }

        public string AreaIdText { get; set; } = string.Empty;
        public string DataDateText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;

        /// <summary>
        /// 直近の情報を取得する
        /// </summary>
        public void Search()
        {
            var entity = this.weather.GetLatest(Convert.ToInt32(this.AreaIdText));

            if (entity is null)
            {
                this.DataDateText = "データなし";
                this.ConditionText = string.Empty;
                this.TemperatureText = string.Empty;
                return;
            }

            this.DataDateText = entity.DataDate.ToString();
            this.ConditionText = entity.Condition.DisplayValue;
            this.TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
                //CommonFunc.RoundString(entity.Temperature,
                //CommonConst.TemperatureDigit) + " "
                //+ CommonConst.TemperatureUnitName;
        }

        /// <summary>
        /// 直近の情報を取得する
        /// </summary>
        //public void Search()
        //{
        //    var dataTable = this.weather.GetLatest(Convert.ToInt32(this.AreaIdText));

        //    if (dataTable.Rows.Count == 0)
        //    {
        //        this.DataDateText = "データなし";
        //        this.ConditionText = string.Empty;
        //        this.TemperatureText = string.Empty;
        //        return;
        //    }

        //    this.DataDateText = dataTable.Rows[0]["DataDate"].ToString();
        //    this.ConditionText = dataTable.Rows[0]["Condition"].ToString();
        //    this.TemperatureText =
        //        CommonFunc.RoundString(Convert.ToSingle(dataTable.Rows[0]["Temperature"]),
        //        CommonConst.TemperatureDigit) + " "
        //        + CommonConst.TemperatureUnitName;
        //}
    }
}
