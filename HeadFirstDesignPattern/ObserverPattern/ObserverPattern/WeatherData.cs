using System;

namespace ObserverPattern
{
    public class WeatherData
    {
        private CurrentConditionsDisplay _currentConditionsDisplay = new CurrentConditionsDisplay();
        private StatisticsDisplay _statisticsDisplay = new StatisticsDisplay();
        private ForecastDisplay _forecastDisplay = new ForecastDisplay();

        public void MeasurementsChanged()
        {
            float temp = GetTemperature();
            float humidity = GetHumidity();
            float pressure = GetPressure();

            _currentConditionsDisplay.Update(temp, humidity, pressure);
            _statisticsDisplay.Update(temp, humidity, pressure);
            _forecastDisplay.Update(temp, humidity, pressure);
        }

        private static float GetTemperature()
        {
            throw new NotImplementedException();
        }

        private static float GetHumidity()
        {
            throw new NotImplementedException();
        }

        private static float GetPressure()
        {
            throw new NotImplementedException();
        }
    }
}