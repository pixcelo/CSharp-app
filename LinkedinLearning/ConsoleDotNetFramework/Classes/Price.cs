using System;

namespace ConsoleDotNetFramework.Classes
{
    /// <summary>
    /// 金額クラス
    /// </summary>
    public sealed class Price
    {
        /// <summary>
        /// システム設定
        /// </summary>
        private readonly ISystemSettings systemSettings;

        /// <summary>
        /// 値 ※データストアに保存する値
        /// </summary>
        public readonly decimal value;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Price(
            ISystemSettings systemSettings,
            decimal value)
        {
            this.systemSettings = systemSettings;
            this.value = value;
        }        

        public string DisplayValue()
        {
            var priceSettings = (PriceSystemSettings)this.systemSettings;
            return Math.Round(this.value, priceSettings.DecimalPlaces).ToString($"F{priceSettings.DecimalPlaces}");
        }
    }
}
