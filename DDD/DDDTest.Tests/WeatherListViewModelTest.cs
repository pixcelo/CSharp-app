using DDD.Domain.Entities;
using DDD.Domain.Repositoriers;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherListViewModelTest
    {
        [TestMethod]
        public void 天気一覧画面シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();

            var entities = new List<WeatherEntity>
            {
                new WeatherEntity(1, Convert.ToDateTime("2024/06/10 4:39:10"), 1, 12.3f),
                new WeatherEntity(2, Convert.ToDateTime("2024/06/15 6:40:53"), 2, 23.4f)
            };

            weatherMock.Setup(x => x.GetData()).Returns(entities);            

            var viewModel = new WeatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);
        }
    }
}
