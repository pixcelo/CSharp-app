using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeratherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            // ViewModel自体をモック化する（public関数の上書きができる）
            var viewModelMock = new Mock<WeatherSaveViewModel>();
            // DateTime.Nowを返す関数を上書き
            viewModelMock.Setup(x => x.GetDataTime()).Returns(
                Convert.ToDateTime("2024/06/10 4:39:10"));

            var viewModel = viewModelMock.Object;

            // 初期値
            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(
                Convert.ToDateTime("2024/06/10 4:39:10"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureValue.Is("");
        }
    }
}
