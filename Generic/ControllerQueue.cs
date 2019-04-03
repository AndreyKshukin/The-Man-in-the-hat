using ConsoleGame.KeyEvents;
using System;
using System.Collections.Generic;

namespace ConsoleGame.Generic
{
    public class ControllerQueue
    {
        private List<ConsoleKeyInfo> _queue = new List<ConsoleKeyInfo>();

        public void Add(ConsoleKeyInfo c)
        {
            bool checkElementInQueue = true;
            foreach (var command in _queue)
            {
                if (command != c) continue;
                checkElementInQueue = false;
                break;
            }

            if(checkElementInQueue)
                _queue.Add(c);
        }

        public void Get(KeyEvent keyEvent)
        {
            var temp = _queue.ToArray();
            foreach (var value in temp)
            {
                keyEvent.OnKeyPress(value);
            }
            _queue.Clear();
        }
    }
}
