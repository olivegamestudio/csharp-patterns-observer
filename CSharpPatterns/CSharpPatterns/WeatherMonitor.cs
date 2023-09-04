namespace CSharp.Patterns.Observer;

public class WeatherMonitor : IObserver<Weather>
{
    IDisposable? _cancellation;
    Weather? _weather;

    public void Subscribe(WeatherReporter reporter) => _cancellation = reporter.Subscribe(this);

    public void Unsubscribe()
    {
        _cancellation?.Dispose();
    }

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(Weather weather)
    {
        _weather = weather;
    }
}
