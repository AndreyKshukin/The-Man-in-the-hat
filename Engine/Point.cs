using ConsoleGame.Interfaces;
using System;

namespace ConsoleGame.Engine
{
    public class Point : ITexture, IPosition
    {
        private char _texture = '#';
        public char Texture { get => _texture; set { _texture = value; } }

        public int Position_x { get; set; }
        public int Position_y { get; set; }
        public string StrTexture { get; internal set; }

        public static implicit operator Point ((int,int,char) value)=>
            new Point { Position_x=value.Item1, Position_y = value.Item2, Texture = value.Item3};

        public void Draw()
        {
            DrawPoint(Texture);
        }

        public void Clear(char texture)
        {
            if (texture != this.Texture)
                DrawPoint(texture);
            else
                DrawPoint(texture);
        }

        private void DrawPoint(char texture)
        {
            Console.SetCursorPosition(Position_x, Position_y);
            Console.Write(texture);
        }
    }
}
