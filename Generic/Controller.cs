using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.KeyEvents;

namespace ConsoleGame.Generic
{
    public abstract class Controller
    {
        protected KeyEvent moveCtrl = new KeyEvent();

        public Controller()
        {
            InitKeyEvents();
        }

        protected virtual void InitKeyEvents()
        {
        }

        public virtual void GetKeyboardInput()
        {
        }
    }
}
