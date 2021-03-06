﻿using EventObserverPattern.Interfaces;
using System;

namespace EventObserverPattern
{
    public class ForecastDisplay : IDisplayElement
    {
        private float _currentPressure = 29.92f;
        private float _lastPressure;

        public void OnMeasurementsChanged(object sender, WeatherData.MeasurementArgs args)
        {
            _lastPressure = _currentPressure;
            _currentPressure = args.Pressure;

            Display();
        }

        public void Display()
        {
            Console.WriteLine("Forecast: ");
            if (_currentPressure > _lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("More of the same");
            }
            else if (_currentPressure < _lastPressure)
            {
                Console.WriteLine("Watch out for cooler, rainy weather");
            }
        }
    }
}