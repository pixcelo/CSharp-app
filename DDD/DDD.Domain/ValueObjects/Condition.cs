using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    /// <summary>
    /// 天気の状態を表す区分クラス
    /// </summary>
    public class Condition : ValueObject<Condition>
    {
        /// <summary>
        /// 不明
        /// </summary>
        public static readonly Condition None = new Condition(0);

        /// <summary>
        /// 晴れ
        /// </summary>
        public static readonly Condition Sunny = new Condition(1);

        /// <summary>
        /// 曇り
        /// </summary>
        public static readonly Condition Cloudy = new Condition(2);

        /// <summary>
        /// 雨
        /// </summary>
        public static readonly Condition Rainy = new Condition(3);

        public Condition(int value)
        {
            this.Value = value;
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                if (this == Sunny)
                {
                    return "晴れ";
                }

                if (this == Cloudy)
                {
                    return "曇り";
                }

                if (this == Rainy)
                {
                    return "雨";
                }

                return "不明";
            }
        }

        protected override bool EqualsCore(Condition other)
        {
            return this.Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
