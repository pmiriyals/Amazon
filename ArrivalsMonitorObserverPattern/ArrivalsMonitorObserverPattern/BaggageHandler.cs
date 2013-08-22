using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrivalsMonitorObserverPattern
{
    //Provider or Subject or Observable: sends notification to observers
    //Implements IObservable<T>: Subscribe method
    //Mechanism to track Observers (maintain a List<IObserver<T>>
    //IDisposable: to remove observers (returned by Subscribe method)
    //T: Object that contains the data that the provider sends to observers

    public class BaggageHandler : IObservable<BaggageInfoModel>
    {
        private List<IObserver<BaggageInfoModel>> observers;
        private List<BaggageInfoModel> flights;

        public BaggageHandler()
        {
            observers = new List<IObserver<BaggageInfoModel>>();
            flights = new List<BaggageInfoModel>();
        }

        public IDisposable Subscribe(IObserver<BaggageInfoModel> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);

                foreach (BaggageInfoModel bi in flights)
                    observer.OnNext(bi);
            }

            return new Unsubscriber<BaggageInfoModel>(observers, observer);
        }

        public void BaggageStatus(int flightID, string origin, int carousel)
        {
            BaggageInfoModel bi = new BaggageInfoModel(flightID, origin, carousel);


        }
    }

    public class Unsubscriber<T> : IDisposable
    {
        private List<IObserver<T>> lstObservers;
        private IObserver<T> observer;

        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            this.lstObservers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if(lstObservers != null && observer != null && lstObservers.Contains(observer))
                lstObservers.Remove(observer);
        }
    }
}
