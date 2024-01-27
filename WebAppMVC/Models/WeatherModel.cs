namespace WebAppMVC.Models
{
    public class WeatherModel
    {
        public TemperatureInfo Main { get; set; }
        public IEnumerable<WeatherDescription> Weather { get; set; }
        public WindInfo Wind { get; set; }
        public string Name { get; set; } // 場所名

        public class TemperatureInfo
        {
            public double Temp { get; set; } // 気温
            public double FeelsLike { get; set; } // 体感気温
            public double TempMin { get; set; } // 最低気温
            public double TempMax { get; set; } // 最高気温
            public int Humidity { get; set; } // 湿度
        }

        public class WeatherDescription
        {
            public string Main { get; set; } // 天気の概要（例：Clear, Rain）
            public string Description { get; set; } // 天気の詳細説明
            public string Icon { get; set; } // 天気アイコン
        }

        public class WindInfo
        {
            public double Speed { get; set; } // 風速
            public int Deg { get; set; } // 風向
        }
    }
}
