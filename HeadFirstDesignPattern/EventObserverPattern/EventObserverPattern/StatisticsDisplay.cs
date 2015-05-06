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

        public void OnMeasurementsChanged(float temp, float humidity, float pressure)
        {
            _tempSum += temp;
            _numReadings++;

            if (temp > _maxTemp)
            {
                _maxTemp = temp;
            }

            if (temp < _minTemp)
            {
                _minTemp = temp;
            }

            Display();
        }

        public void Display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + (_tempSum / _numReadings) + "/" + _maxTemp + "/" + _minTemp);
        }
    }
}