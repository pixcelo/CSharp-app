namespace DDD.Domain.ValueObjects
{
    /// <summary>
    /// 値オブジェクトの基底クラス
    /// 値オブジェクトを継承する型だけに制限するため、ジェネリック型を指定
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// 値オブジェクト同士が等しいかどうかを判定する
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;
            if (valueObject is null)
            {
                return false;
            }

            return EqualsCore(valueObject);
        }

        /// <summary>
        /// 値オブジェクト同士が等しいかどうかを判定する
        /// </summary>
        /// <param name="vo1"></param>
        /// <param name="vo2"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        protected abstract bool EqualsCore(T other);
        protected abstract int GetHashCodeCore();

        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// ハッシュ値も値オブジェクトの値を基に生成する
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.GetHashCodeCore();
        }
    }
}
