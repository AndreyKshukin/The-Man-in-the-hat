using System;

namespace ConsoleGame.Interfaces
{
    public interface IEventsHub<T> where T: struct 
    {
        void Register(T type, Action<EventArgs> action);
        
        void Unregister(T type, Action<EventArgs> action);

        void Rise(T type, EventArgs args);
    }
}