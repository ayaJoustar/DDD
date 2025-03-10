﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Entities;

namespace DDD.Domain.Repositories
{
    public interface IWeatherRepository
    {
        WeatherEntity GetLatest(int areaId);
        IReadOnlyList<WeatherEntity> GetData();

        void Save(WeatherEntity weather);
    }
}
