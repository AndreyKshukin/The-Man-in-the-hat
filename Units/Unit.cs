using ConsoleGame.Engine;
using ConsoleGame.Interfaces;
using log4net;
using System;
using System.Collections.Generic;

namespace ConsoleGame.Units
{
    public class Unit : IPosition, ISize
    {
        protected List<Point> viewUnit;
        
        public int Position_x { get; set; }
        public int Position_y { get; set; }

        public int Size_x { get; set; }
        public int Size_y { get; set; }

        public Unit(int pos_x, int pos_y, int size_x, int size_y)
        {
            Position_x = pos_x;
            Position_y = pos_y;

            Size_x = size_x;
            Size_y = size_y;

            viewUnit = new List<Point>();
            Point p = (pos_x, pos_y, '#');
            viewUnit.Add(p);

            //UpdateView();
        }

        public void UpdateView()
        {
            foreach (var item in viewUnit)
            {
                if (item.Position_y == Position_y && item.Position_x == Position_x)
                    continue;
                ITexture texture = Program.LevelMap.WorldMap[item.Position_y, item.Position_x];
                item.Clear(texture.Texture);
                item.Position_x = Position_x;
                item.Position_y = Position_y;
                item.Draw();
            }
        }
    }
}