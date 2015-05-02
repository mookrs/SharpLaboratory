using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class WeatherData : ISubject
    {
        private List<IObserver> _observers;
        private float _temperature;
        private float _humidity;
        private float _pressure;

        private CurrentConditionsDisplay _currentConditionsDisplay = new CurrentConditionsDisplay();
        private StatisticsDisplay _statisticsDisplay = new StatisticsDisplay();
        private ForecastDisplay _forecastDisplay = new ForecastDisplay();

        public WeatherData()
        {
            _observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            int i = _observers.IndexOf(o);
            if (i >= 0)
            {
                _observers.RemoveAt(i);
            }
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(_temperature, _humidity, _pressure);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
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