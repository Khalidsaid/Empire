using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Observers
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);

        void UnSubscribe(IObserver observer);
        void Notify();
    }
}
