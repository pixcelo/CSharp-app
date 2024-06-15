using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositoriers;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeratherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var areasMock = new Mock<IAreasRepository>();
            var areas = new List<AreaEntity>
            {
                new AreaEntity(1, "東京"),
                new AreaEntity(2, "大阪")
            };
            areasMock.Setup(x => x.GetData()).Returns(areas);

            // ViewModel自体をモック化する（public関数の上書きができる）
            var viewModelMock = new Mock<WeatherSaveViewModel>(areasMock.Object);
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
            viewModel.Areas.Count.Is(2);
            viewModel.Conditions.Count.Is(4);

            // 登録の処理            
            var exception = AssertEx.Throws<InputException>(() => viewModel.Save());
            exception.Message.Is("エリアを選択してください");
        }
    }
}
