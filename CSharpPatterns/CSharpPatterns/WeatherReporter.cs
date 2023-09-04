using System;

namespace CSharp.Patterns.Observer;

public class WeatherReporter : IObservable<Weather>
{
    readonly HashSet<IObserver<Weather>> _observers = new();
    Weather _weather = new() { Temperature = 37, WeatherType = WeatherType.Cloudy };

    public IDisposable Subscribe(IObserver<Weather> observer)
    {
        if (_observers.Add(observer))
        {
            observer.OnNext(_weather);
        }

        return new Unsubscriber<Weather>(_observers, observer);
    }
}
