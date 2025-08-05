using Hospital.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class MenuState : IMenu
    {

        private static MenuState _instance;
        public static MenuState Instance => _instance ??= new MenuState();

        Stack<IMenu> _menuStack;

        MenuState()
        {
            _menuStack = new Stack<IMenu>();
        }

        // Method comments are available on the IMenu interface
        public void Load()
        {
            if (_menuStack.Count > 0)
                _menuStack.Peek().Load();
            else
                throw new InvalidOperationException("There is no menu on the menu stack to load");
        }

        public void Show()
        {
            if(_menuStack.Count > 0)
                _menuStack.Peek().Show();
            else
                throw new InvalidOperationException("There is no menu on the menu stack");
        }

        // Add a new menu to the top of the stack
        public void Push(IMenu menu)
        {
            _menuStack.Push(menu);
            menu.Load();
        }

        // Remove the top menu from the stack and load the one beneath it
        public void Pop()
        {
            if (_menuStack.Count > 0)
                _menuStack.Pop();
            else
                throw new InvalidOperationException("There is no menu on the menu stack to pop");
            
            Load();
        }

    }
}
