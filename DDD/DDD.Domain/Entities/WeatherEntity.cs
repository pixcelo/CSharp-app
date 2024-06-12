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
        {            
            this.AreaId = areaId;
            this.DataDate = dataDate;
            this.Condition = condition;
            this.Temperature = new Temperature(temperature);
        }

        // プロパティはインスタンス生成時に設定された値を変更できないようにする
        public int AreaId { get; }        
        public DateTime DataDate { get; }
        public int Condition { get; }
        public Temperature Temperature { get; }
    }
}
