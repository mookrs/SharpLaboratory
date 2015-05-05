using System;

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
            // 赋值给另一个委托变量，可确保在检查null值和发送通知之间，假如所有订阅者（由一个不同的线程）移除，
            // 不会引发NullReferenceException异常
            Action<float, float, float> localOnChange = OnMeasurementsChange;
            // 避免当前没有订阅者注册接收通知，触发事件之前检查null值
            if (localOnChange != null)
            {
                localOnChange(_temperature, _humidity, _pressure);
            }
        }
    }
}