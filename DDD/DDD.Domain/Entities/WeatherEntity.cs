using DDD.Domain.ValueObjects;
using System;

namespace DDD.Domain.Entities
{
    /// <summary>
    /// 天気エンティティ
    /// </summary>
    public sealed class WeatherEntity
    {
        /// <summary>
        /// 完全コンストラクタパターン
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="dataDate"></param>
        /// <param name="condition"></param>
        /// <param name="temperature"></param>
        public WeatherEntity(
            int areaId,
            DateTime dataDate,
            int condition,
            float temperature)
            : this(areaId, string.Empty, dataDate, condition, temperature)
        {
        }

        public WeatherEntity(
            int areaId,
            string areaName,
            DateTime dataDate,
            int condition,
            float temperature)
        {
            this.AreaId = areaId;
            this.AreaName = areaName;
            this.DataDate = dataDate;
            this.Condition = new Condition(condition);
            this.Temperature = new Temperature(temperature);
        }

        // プロパティはインスタンス生成時に設定された値を変更できないようにする
        public int AreaId { get; }
        public string AreaName { get; }
        public DateTime DataDate { get; }
        public Condition Condition { get; }
        public Temperature Temperature { get; }
    }
}
