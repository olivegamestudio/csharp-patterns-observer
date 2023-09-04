namespace CSharp.Patterns.Observer;

internal sealed class Unsubscriber<T> : IDisposable
{
    readonly ISet<IObserver<T>> _observers;
    readonly IObserver<T> _observer;

    internal Unsubscriber(
        ISet<IObserver<T>> observers,
        IObserver<T> observer) => (_observers, _observer) = (observers, observer);

    public void Dispose() => _observers.Remove(_observer);
}
