using EventObserverPattern.Interfaces;
using System;

namespace EventObserverPattern
{
    public class CurrentConditionsDisplay : IDisplayElement
    {
        private float _temperature;
        private float _humidity;

        public void OnMeasurementsChanged(object sender, WeatherData.MeasurementArgs args)
        {
            _temperature = args.Temperature;
            _humidity = args.Humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature + "F degrees and " + _humidity + "% humidity");
        }
    }
}