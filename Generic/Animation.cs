using System.Runtime.CompilerServices;
using ConsoleGame.Engine;
using ConsoleGame.Interfaces;
using ConsoleGame.Units;

namespace ConsoleGame.Generic
{
    public class Animation : ISize, IPosition
    {
        private Unit _unit;
        private ShapeString _shape;
        private readonly int _countFrames;
        private float _numberFrames = 1f;
        private string[][] _str;        //первая ячейка указывает на количество кадров с анимацией, вторая - количество строк по высоте

        public int Size_x { get; set; }
        public int Size_y { get; set; }

        public int Position_x { get; set; }
        public int Position_y { get; set; }

        public Animation(Unit unit, string[] str)
        {
            _unit = unit;
            Size_x = unit.Size_x;
            Size_y = unit.Size_y;

            Position_x = 50;
            Position_x = 20;

            _countFrames = str.Length;
            _str = new string[_countFrames][];

            for (int i = 0; i < _countFrames; i++)
            {
                _str[i] = new string[Size_y];
            }

            for (int i = 0; i < str.Length; i++)
            {
                LoadShapeTexure(i, str[i]);
            }

            _shape = new ShapeString(unit);
            UpdateShape();
        }

        private void LoadShapeTexure(int numberFrame, string str)
        {
            int counter = 0;
            for (int i = 0; i < Size_y; i++)
            {
                for (int j = 0; j < Size_x; j++)
                {
                    _str[numberFrame][i] += str[counter];
                    counter++;
                }
            }
        }

        public void ClearPosition()
        {
            _shape.Clear();
        }

        public virtual void StartFrameAnimation(int frame)
        {
            _numberFrames = (float)frame;
        }

        public void UpdateShape()
        {
            if (Position_x != _unit.Position_x || Position_y != _unit.Position_y)
            {
                if (_numberFrames >= _countFrames)
                {
                    _numberFrames = 0;
                }

                Position_x = _unit.Position_x;
                Position_y = _unit.Position_y;
                _shape.SetShape(_str[(int)_numberFrames]);
                _shape.UpdateShape(_unit);
                _numberFrames+=0.40f;
            }

            else if (_numberFrames != 0)
            {
                _numberFrames = 0;
                _shape.SetShape(_str[(int)_numberFrames]);
                _shape.UpdateShape(this);
            }
        }
    }
}
