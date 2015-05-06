using System;

namespace EventObserverPattern
{
    public class WeatherData
    {
        public class MeasurementArgs : System.EventArgs
        {
            public float Temperature { get; set; }
            public float Humidity { get; set; }
            public float Pressure { get; set; }

            public MeasurementArgs(float temperature, float humidity, float pressure)
            {
                Temperature = temperature;
                Humidity = humidity;
                Pressure = pressure;
            }
        }

        private float _temperature;
        private float _humidity;
        private float _pressure;
        public event EventHandler<MeasurementArgs> OnMeasurementsChange = delegate { };

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;

            if (OnMeasurementsChange != null)
            {
                OnMeasurementsChange(this, new MeasurementArgs(_temperature, _humidity, _pressure));
            }
        }
    }
}