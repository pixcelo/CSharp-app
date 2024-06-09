using DDD.Domain.Repositoriers;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var viewModel = new WeatherLatestViewModel(new WeatherMock());

            // 初期状態
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            // 情報の取得
            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2024/06/10 4:39:10", viewModel.DataDateText);
            Assert.AreEqual("2", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);
        }
    }

    /// <summary>
    /// Weatherのモック
    /// </summary>
    internal class WeatherMock : IWeatherRepository
    {
        public DataTable GetLatest(int areaId)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("AreaId", typeof(int));
            dataTable.Columns.Add("DataDate", typeof(DateTime));
            dataTable.Columns.Add("Condition", typeof(int));
            dataTable.Columns.Add("Temperature", typeof(float));

            var newRow = dataTable.NewRow();
            newRow["AreaId"] = 1;
            newRow["DataDate"] = Convert.ToDateTime("2024/06/10 4:39:10");
            newRow["Condition"] = 2;
            newRow["Temperature"] = 12.3f;

            dataTable.Rows.Add(newRow);
            return dataTable;
        }
    }

}
