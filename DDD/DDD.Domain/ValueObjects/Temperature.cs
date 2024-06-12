namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        private string UnitName = "℃";
        private int Digit = 2;

        public Temperature(float value)
        {
            this.Value = value;
        }

        public float Value { get; }

        /// <summary>
        /// 例：12.30
        /// </summary>
        public string DisplayValue
        {
            get
            {
                return CommonFunc.RoundString(Value, this.Digit);
            }
        }

        /// <summary>
        /// 例：12.30℃
        /// </summary>
        public string DisplayValueWithUnit
        {
            get
            {
                return CommonFunc.RoundString(Value, this.Digit)
                        + this.UnitName;
            }
        }

        /// <summary>
        /// 例：12.30 ℃
        /// </summary>
        public string DisplayValueWithUnitSpace
        {
            get
            {
                return CommonFunc.RoundString(Value, this.Digit)
                        + " " + this.UnitName;
            }
        }

        /// <summary>
        /// 抽象メソッドで値オブジェクト同士が等しいかどうかを判定する
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// 値オブジェクト同士が等しいかどうかを判定する
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public override bool Equals(object obj)
        //{
        //    var valueObject = obj as Temperature;
        //    if (valueObject is null)
        //    {
        //        return false;
        //    }

        //    return Value == valueObject.Value;
        //}

        /// <summary>
        /// 値オブジェクト同士が等しいかどうかを判定する
        /// </summary>
        /// <param name="vo1"></param>
        /// <param name="vo2"></param>
        /// <returns></returns>
        //public static bool operator ==(Temperature vo1, Temperature vo2)
        //{
        //    return Equals(vo1, vo2);
        //}

        //public static bool operator !=(Temperature vo1, Temperature vo2)
        //{
        //    return !Equals(vo1, vo2);
        //}
    }
}
