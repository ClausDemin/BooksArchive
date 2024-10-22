using InfrastructureInterfaces;
using System.Drawing;


namespace LibraryView
{
    public class SwitchableMenu
    {
        private List<MenuItem> _items;
        private MenuItem _item;
        private int _itemIndex;

        private Point _cursorPosition;
        private char _cursorSymbol;

        public SwitchableMenu(Point cursorPosition = new Point(), char cursorSymbol = '>') 
        { 
            _items = new List<MenuItem>();
            _cursorPosition = cursorPosition;
            _cursorSymbol = cursorSymbol;
        }

        public SwitchableMenu(List<MenuItem> items, Point cursorPosition = new Point(), char cursorSymbol = '>')
        {
            _items = items;
            _cursorPosition = cursorPosition;
            _cursorSymbol = cursorSymbol;
            _item = _items[0];
            _itemIndex = 0;
        }

        public int Length => GetMaxLength();

        public void Add(MenuItem item) 
        {
            if (_items.Count == 0) 
            { 
                _item = item;
                _itemIndex = 0;
            }

            _items.Add(item);
        }

        public void AddRange(IEnumerable<MenuItem> items) 
        { 
            _items.AddRange(items);
        }

        public void SwitchToNext() 
        {
            if (IsCursorInBounds(new Point(_cursorPosition.X, _cursorPosition.Y + 1))) 
            {
                ClearPreviousPosition();

                _cursorPosition.Y++;
                _item = _items[++_itemIndex];

                Console.SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

                Console.Write(_cursorSymbol);
            }
        }

        public void SwitchToPrevious() 
        {
            if (IsCursorInBounds(new Point(_cursorPosition.X, _cursorPosition.Y - 1))) 
            {
                ClearPreviousPosition();

                _cursorPosition.Y--;
                _item = _items[--_itemIndex];

                Console.SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

                Console.Write(_cursorSymbol);
            }
        }

        public void ApplyChoice() 
        {
            if (_item != null) 
            {
                _item.Click();
            }
        }

        public void DrawMenu() 
        {
            Console.SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

            foreach (var item in _items) 
            { 
                Console.WriteLine(item);
            }

            Console.SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

            Console.Write(_cursorSymbol);

            if (_items.Count > 0) 
            { 
                _item = _items[0];
            }
        }

        private void ClearPreviousPosition() 
        {
            Console.SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);
            Console.Write(' ');
        }

        public void ClearOutput() 
        {
            int cursorPositionTop = _items.Count;
            int cursorPositionLeft = GetMaxLength();

            for (int i = cursorPositionTop; i >= 0; i--) 
            {
                for (int j = cursorPositionLeft; j >= 0; j--) 
                {
                    Console.SetCursorPosition(j, i);

                    Console.Write(' ');
                }
            }

            _cursorPosition.X = 0;
            _cursorPosition.Y = 0;
            _itemIndex = 0;
        }

        private bool IsCursorInBounds(Point nextCursorPosition) 
        {
            return nextCursorPosition.Y >= 0 && nextCursorPosition.Y < _items.Count; 
        }

        private int GetMaxLength() 
        { 
            int maxLength = int.MinValue;

            foreach (var item in _items) 
            {
                if (item.Length > maxLength) 
                { 
                    maxLength = item.Length;
                }
            }

            return maxLength;
        }
    }
}
