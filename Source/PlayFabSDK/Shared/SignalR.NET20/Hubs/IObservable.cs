using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Client._20.Hubs
{
    public interface IObservable<T>
    {
        IDisposable Subscribe(IObserver<T> observer);
    }
}
