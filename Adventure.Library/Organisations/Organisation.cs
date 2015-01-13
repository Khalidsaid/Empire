using Adventure.Library.Observers;
using System;
using System.Collections.Generic;

namespace Adventure.Library.Organisations
{
    public enum OrganisationState { War, Peace }
    public class Organisation : IObservable
    {
        public string Name { get; set; }
        public Organisation Parent { get; set; }
        public OrganisationState State { get; private set; }
        private readonly IList<IObserver> observers;

        public Organisation(string name, OrganisationState state = OrganisationState.Peace)
        {
            this.Name = name;
            this.observers = new List<IObserver>();
            this.State = state;
        }

        public Organisation(string name, Organisation parent, OrganisationState state = OrganisationState.Peace)
        {
            this.Name = name;
            this.observers = new List<IObserver>();
            this.Parent = parent;
            this.State = state;
        }

        public virtual void Subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public virtual void UnSubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public virtual void Notify()
        {
            foreach (var observer in this.observers)
            {
                observer.Update();
            }
        }
    }

}
