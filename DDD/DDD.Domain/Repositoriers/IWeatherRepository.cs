using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Repositoriers
{
    public interface IWeatherRepository
    {
        /// <summary>
        /// 直近値を取得する
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        WeatherEntity GetLatest(int areaId);

        /// <summary>
        /// 天気情報を取得する
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<WeatherEntity> GetData();
    }
}
