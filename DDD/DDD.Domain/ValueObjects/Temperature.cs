namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature
    {
        private string UnitName = "℃";
        private int Digit = 2;

        public Temperature(float value)
        {
            this.Value = value;
        }

        public float Value { get; }
        public string DisplayValue
        {
            get
            {
                return CommonFunc.RoundString(Value, this.Digit)
                        + " " + this.UnitName;
            }
        }
    }
}
