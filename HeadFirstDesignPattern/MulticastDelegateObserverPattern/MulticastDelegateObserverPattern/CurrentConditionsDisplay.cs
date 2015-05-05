using MulticastDelegateObserverPattern.Interfaces;
using System;

namespace MulticastDelegateObserverPattern
{
    public class CurrentConditionsDisplay : IDisplayElement
    {
        private float _temperature;
        private float _humidity;

        public void OnMeasurementsChanged(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature + "F degrees and " + _humidity + "% humidity");
        }
    }
}