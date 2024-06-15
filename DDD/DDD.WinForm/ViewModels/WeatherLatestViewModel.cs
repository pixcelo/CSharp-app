using DDD.Domain.Repositoriers;
using DDD.Infrastracture.SQLite;
using DDD.WinForm.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel : INotifyPropertyChanged
    {
        private IWeatherRepository weather;        

        // 本番コード：引数無しコンストラクタを呼び出すとSQLiteが注入される
        // テストコード：引数付きコンストラクタを呼び出し、任意のリポジトリを注入する

        /// <summary>
        /// コンストラクタ　thisで引数付きコンストラクタを呼び出す
        /// </summary>
        public WeatherLatestViewModel() : this(new WeatherSQLite())
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="weather"></param>
        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            this.weather = weather;
        }

        // 値が変更されたときにOnPropertyChagedを呼び出す
        private string areaIdText = string.Empty;
        public string AreaIdText
        {
            get { return this.areaIdText; }
            set
            {
                if (this.areaIdText == value) return;

                this.areaIdText = value;
                OnPropertyChaged(nameof(AreaIdText));
            }
        }

        private string dataDateText = string.Empty;
        public string DataDateText
        {
            get { return this.dataDateText; }
            set
            {
                if (this.dataDateText == value) return;

                this.dataDateText = value;
                OnPropertyChaged(nameof(DataDateText));
            }
        }

        private string conditionText = string.Empty;
        public string ConditionText
        {
            get { return this.conditionText; }
            set
            {
                if (this.conditionText == value) return;

                this.conditionText = value;
                OnPropertyChaged(nameof(ConditionText));
            }
        }

        private string temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return this.temperatureText; }
            set
            {
                if (this.temperatureText == value) return;

                this.temperatureText = value;
                OnPropertyChaged(nameof(TemperatureText));
            }
        }

        //public string AreaIdText { get; set; } = string.Empty;
        //public string DataDateText { get; set; } = string.Empty;
        //public string ConditionText { get; set; } = string.Empty;
        //public string TemperatureText { get; set; } = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 直近の情報を取得する
        /// </summary>
        public void Search()
        {
            if (string.IsNullOrEmpty(this.AreaIdText)) return;

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

            // すべてのプロパティを更新
            //this.OnPropertyChaged(string.Empty);
        }

        /// <summary>
        /// 値の変更時にプロパティを同期する
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChaged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
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
