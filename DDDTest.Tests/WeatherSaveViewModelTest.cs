using System;
using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System.Collections.Generic;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DDD.Domain.Exceptions;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            var areasMock = new Mock<IAreasRepository>();

            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "神戸"));

            areasMock.Setup(_ => _.GetData()).Returns(areas);

            //Mockの引数に渡すことでWeatherSaveViewModelの引数として渡せる
            var viewModelMock = new Mock<WeatherSaveViewModel>(weatherMock.Object,areasMock.Object);
            viewModelMock.Setup(_ => _.GetDateTime()).Returns(Convert.ToDateTime("2018/01/01 12:34:56"));

            var viewModel = viewModelMock.Object;

            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");
            viewModel.TemperatureUnitName.Is("℃");

            viewModel.Areas.Count.Is(2);
            viewModel.Conditions.Count.Is(4);

            var ex =  AssertEx.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("エリアを選択してください");

            viewModel.SelectedAreaId = 2;
            ex = AssertEx.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("温度の入力に誤りがあります");

            viewModel.TemperatureText = "12.345";

            weatherMock.Setup(_ => _.Save(It.IsAny<WeatherEntity>())).
                Callback<WeatherEntity>(saveValue =>
                {
                    saveValue.AreaId.Value.Is(2);
                    saveValue.DataDate.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
                    saveValue.Condition.Value.Is(1);
                    saveValue.Temperature.Value.Is(12.345f);
                });

            viewModel.Save();
            weatherMock.VerifyAll();
        }
    }
}
