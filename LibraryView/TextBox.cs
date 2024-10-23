using System;
using System.Drawing;

namespace LibraryView
{
    public class TextBox
    {
        private Point _position;
        private int _length;
        private int _marginRight;

        public TextBox(int cursorPositionLeft, int cursorPositionTop, int textBoxLength, int marginRight = 5)
        {
            _position = new Point(cursorPositionLeft, cursorPositionTop);
            _marginRight = marginRight;
            _length = textBoxLength - marginRight;
        }

        public void UpdateText(string[] text, ConsoleColor textColor = ConsoleColor.Gray)
        {
            ClearOutput();

            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = textColor;

            Console.SetCursorPosition(_position.X, _position.Y);

            var lastInputLength = 0;

            foreach (var line in text)
            {
                for (int i = 0, j = 0; i < line.Length; i++, j++)
                {
                    Console.Write(line[i]);
                    if (j >= _length - 1)
                    {
                        Console.Write('\n');
                        Console.SetCursorPosition(_position.X, ++_position.Y);
                        j = 0;
                    }
                }
                Console.SetCursorPosition(_position.X, ++_position.Y);

                lastInputLength = line.Length;
            }

            if (_position.Y > 0) 
            {
                --_position.Y;

                int userInputPositionY = (lastInputLength + _marginRight * _position.Y) % _position.X;

                Console.SetCursorPosition(_position.X + userInputPositionY, _position.Y);
            }

            Console.ForegroundColor = defaultColor;
        }

        public string GetUserInput(string message) 
        {
            Console.CursorVisible = true;

            ClearOutput();

            UpdateText([message]);

            string output = Console.ReadLine();

            Console.CursorVisible = false;

            return output;
        }

        private void ClearOutput() 
        {
            for (int i = _position.Y; i >= 0; i--) 
            {
                for (int j = Console.BufferWidth - 1; j >= _position.X; j--) 
                { 
                    Console.SetCursorPosition(j, i);
                    Console.Write(' ');
                }
            }

            _position.Y = Console.GetCursorPosition().Top;
        }
    }
}
