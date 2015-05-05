using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegateObserverPattern
{
    public class WeatherData
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;
        public Action<float, float, float> OnMeasurementsChange { get; set; }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            OnMeasurementsChange(_temperature, _humidity, _pressure);
        }
    }
}
