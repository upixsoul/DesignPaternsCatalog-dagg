
namespace BehavioralPatterns.Observer
{
    //The subject
    //You define a subject class, TemperatureSensor, that implements IObservable<int>.
    //This means it can send temperature updates to any observer.
    public class TemperatureSensor : IObservable<int>
    {
        private List<IObserver<int>> observers = new();
        private int currentTemperature;

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            // Optionally provide current state
            observer.OnNext(currentTemperature);

            return new Unsubscriber(observers, observer);
        }

        public void SetTemperature(int newTemp)
        {
            currentTemperature = newTemp;
            foreach (var observer in observers)
                observer.OnNext(currentTemperature);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<int>> _observers;
            private IObserver<int> _observer;

            public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }

    //One observer
    //You also define an observer class, TemperatureAlert, which implements IObserver<int>.
    //It reacts whenever it receives a new temperature value.
    public class TemperatureAlert : IObserver<int>
    {
        public void OnCompleted() => Console.WriteLine("No more data.");
        public void OnError(Exception error) => Console.WriteLine($"Error: {error.Message}");
        public void OnNext(int value)
        {
            if (value > 30)
                Console.WriteLine($"⚠️ High Temperature Alert: {value}°C");
        }
    }

}
