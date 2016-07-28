using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Client._20.Hubs
{
    public interface IObserver<T>
    {
        void OnNext(T value);
    }
}
