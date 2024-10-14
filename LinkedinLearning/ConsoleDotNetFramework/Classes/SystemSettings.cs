namespace ConsoleDotNetFramework.Classes
{
    public interface ISystemSettings
    {
    }

    public sealed class PriceSystemSettings : ISystemSettings
    {
        private readonly int setting1;
        private readonly int setting2;
        private readonly bool setting3;
        private readonly int decimalPlaces;

        public PriceSystemSettings(
            int setting1,
            int setting2,
            bool setting3,
            int decimalPlaces)
        {
            this.setting1 = setting1;
            this.setting2 = setting2;
            this.setting3 = setting3;
            this.decimalPlaces = decimalPlaces;
        }

        public int Setting1 { get { return this.setting1; } }
        public int Setting2 { get { return this.setting2; } }
        public bool Setting3 { get { return this.setting3; } }
        public int DecimalPlaces { get { return this.decimalPlaces; } }
    }
}