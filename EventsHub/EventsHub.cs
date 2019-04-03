using ConsoleGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.EventsHub
{
    public class EventsHub<T> : IEventsHub<T> where T : struct
    {
        private readonly Dictionary<T, List<Action<EventArgs>>> _eventHandlers = new Dictionary<T, List<Action<EventArgs>>>();


        public void Rise(T type, EventArgs args)
        {
            if (_eventHandlers.ContainsKey(type))
            {
                var handlers = _eventHandlers[type];

                for (var i = 0; i < handlers.Count; i++)
                {
                    Invoke(handlers[i], args);
                }
            }
        }


        private void Invoke(Action<EventArgs> action, EventArgs args)
        {
            action(args);
        }


        public void Register(T type, Action<EventArgs> action)
        {
            if (_eventHandlers.ContainsKey(type))
            {
                var handlers = _eventHandlers[type];
                handlers.Add(action);
            }
            else
            {
                _eventHandlers.Add(type, new List<Action<EventArgs>>() { action });
            }
        }


        public void Unregister(T type, Action<EventArgs> action)
        {
            List<Action<EventArgs>> actionList;
            _eventHandlers.TryGetValue(type, out actionList);
            if (actionList?.Any() == true && actionList.Contains(action))
            {
                actionList.Remove(action);
            }
        }
    }
}