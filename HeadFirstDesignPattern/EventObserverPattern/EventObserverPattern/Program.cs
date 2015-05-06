using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventObserverPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var currentConditionsDisplay = new CurrentConditionsDisplay();
            var statisticsDisplay = new StatisticsDisplay();
            var forecastDisplay = new ForecastDisplay();
            var heatIndexDisplay = new HeatIndexDisplay();

            weatherData.OnMeasurementsChange += currentConditionsDisplay.OnMeasurementsChanged;
            //weatherData.OnMeasurementsChange += statisticsDisplay.OnMeasurementsChanged;
            //weatherData.OnMeasurementsChange += forecastDisplay.OnMeasurementsChanged;
            //weatherData.OnMeasurementsChange += heatIndexDisplay.OnMeasurementsChanged;

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.SetMeasurements(78, 90, 29.2f);

            Console.ReadKey();
        }
    }
}
