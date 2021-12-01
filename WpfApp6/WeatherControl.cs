using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    class WeatherControl : DependencyObject
    {

        public static readonly DependencyProperty TemperatureProperty;

        public string[] wind = { "Северный", "Южный", "Восточный", "Западный", "Северо-восточный", "Северо-Западный", "Юго-восточный", "Юго-ападный" };
        public enum Weathertoday { Sunny, Cloudy, Rainy, Snowy };
        public int wind_speed;

        public int Wind_speed
        {
            get
            {
                return wind_speed;
            }
            set
            {
                if (value >= 0)
                {
                    wind_speed = value;
                }
                
            }
        }

        public double Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(nameof(Temperature), typeof(double), typeof(WeatherControl),
                                                              new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, new CoerceValueCallback(CoerceTemperature)),
                                                              new ValidateValueCallback(ValidateTemperature));
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            double v = (double)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return false;
        }

        private static bool ValidateTemperature(object value)
        {
            double v = (double)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }
    }
}
