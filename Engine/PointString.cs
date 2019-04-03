using ConsoleGame.Interfaces;
using System;

namespace ConsoleGame.Engine
{
    public class PointString : IPosition
    {
        private string _strTexture = "";
        public string StrTexture { get => _strTexture; set { _strTexture = value; } }

        public int Position_x { get; set; }
        public int Position_y { get; set; }

        public static implicit operator PointString((int, int, string) value) =>
            new PointString { Position_x = value.Item1, Position_y = value.Item2, StrTexture = value.Item3 };

        //проприсовка на новой позиции
        public void DrawString()
        {
            DrawPoint(StrTexture);
        }

        // стираем предыдущую позицию элемента
        public void Clear()
        {
            string str = "";
            for (int i = 0; i < StrTexture.Length; i++)
            {
                str += '?';
            }
            DrawPoint(str);
        }

        private void DrawPoint(string texture)
        {
            string str = SetTexturWorld(texture);
            Console.SetCursorPosition(Position_x - (int)(StrTexture.Length / 2), Position_y);
            Console.Write(str);
        }

        // Считываем текстуру с карты
        private string SetTexturWorld(string strTexture)
        {
            string str = "";
            for (int i = 0; i < strTexture.Length; i++)
            {
                if (strTexture[i] == '?')
                {
                    char ch = Program.LevelMap.WorldMap[Position_x - (int)(StrTexture.Length / 2), Position_y].Texture;
                    str += ch;
                }
                else
                {
                    str += strTexture[i];
                }
            }
            return str;
        }
    }
}
