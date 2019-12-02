using System;
using System.Collections.Generic;

namespace Example_07.Observers
{
    public interface IObserver
    {
        void Attach(IObservable observable);
        void Detach(IObservable observable);
        void Share(string message);
    }

    public class LessonObserver : IObserver
    {
        private readonly IList<IObservable> _observables;

        public LessonObserver()
        {
            _observables = new List<IObservable>();
        }

        public void Attach(IObservable observable)
        {
            _observables.Add(observable);
            observable.Observer = this;
        }

        public void Detach(IObservable observable)
        {
            _observables.Remove(observable);
            observable.Observer = null;
        }

        public void Share(string message)
        {
            foreach (var observable in _observables)
            {
                observable.Hear(message);
            }
        }

        public void Ring()
        {
            Share("ringing");
        }
    }

    public interface IObservable
    {
        IObserver Observer { get; set; }
        void Hear(string message);
        void Say(string message);
    }

    public abstract class ObservableBase : IObservable
    {
        public IObserver Observer { get; set; }
        protected readonly string Name;

        protected ObservableBase(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Console.WriteLine($@"{Name} said ""{message}""");
            Observer.Share(message);
        }

        public abstract void Hear(string message);
    }

    public class Student : ObservableBase
    {
        public Student(string name) : base(name) { }

        public override void Hear(string message)
        {
            Console.WriteLine($@"  {Name} heared ""{message}""");
        }
    }

    public class Lector : ObservableBase
    {
        public Lector(string name) : base(name) { }

        public override void Hear(string message)
        {
            Console.WriteLine($@"  {Name} heared ""{message}""");

            if (message.EndsWith("!"))
            {
                Say("SHUT UP");
            }

            if (message.EndsWith("?"))
            {
                Say("answer");
            }
        }
    }
}