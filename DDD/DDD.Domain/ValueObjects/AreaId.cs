namespace DDD.Domain.ValueObjects
{
    /// <summary>
    /// エリアID
    /// </summary>
    public sealed class AreaId : ValueObject<AreaId>
    {

        public AreaId(int value)
        {
            this.Value = value;
        }
        
        public int Value { get; }

        protected override bool EqualsCore(AreaId other)
        {
            return this.Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        /// <summary>
        /// 0埋めした値を取得
        /// </summary>
        public string DisplayValue
        {
            get
            {
                return Value.ToString().PadLeft(4, '0');
            }
        }
    }
}
