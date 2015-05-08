using EventObserverPattern.Interfaces;
using System;

namespace EventObserverPattern
{
    public class StatisticsDisplay : IDisplayElement
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 200;
        private float _tempSum = 0.0f;
        private int _numReadings;

        public void OnMeasurementsChanged(object sender, WeatherData.MeasurementArgs args)
        {
            _tempSum += args.Temperature;
            _numReadings++;

            if (args.Temperature > _maxTemp)
            {
                _maxTemp = args.Temperature;
            }

            if (args.Temperature < _minTemp)
            {
                _minTemp = args.Temperature;
            }

            Display();
        }

        public void Display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + (_tempSum / _numReadings) + "/" + _maxTemp + "/" + _minTemp);
        }
    }
}