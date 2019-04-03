using ConsoleGame.Interfaces;

namespace ConsoleGame.Engine
{
    public class Shape
    {
        private Point[,] _viewer;

        public Shape(int size_x, int size_y)
        {
            _viewer = new Point[size_y, size_x];
            for (int i = 0; i < size_y; i++)
            {
                for (int j = 0; j < size_x; j++)
                {
                    Point p = (5, 5, '*');
                    _viewer[i, j]= p;
                }
            }
        }

        public void SetShape(Point[,] shape)
        {
            _viewer = shape;
        }

        public void UpdateShape(IPosition pos)
        {
            int y = ((_viewer.GetLength(0) % 2 == 0) ? -1 : 0) 
                + (int)(_viewer.GetLength(0) / 2);

            int x = (int)(_viewer.GetLength(1) / 2);

            if (pos.Position_y != _viewer[y, x].Position_y || pos.Position_x != _viewer[y, x].Position_x)
            {
                for (int i = 0; i < _viewer.GetLength(0); i++)
                {
                    for (int j = 0; j < _viewer.GetLength(1); j++)
                    {
                        ITexture texture = Program.LevelMap.WorldMap[
                            _viewer[i, j].Position_x, _viewer[i, j].Position_y];

                        _viewer[i, j].Clear(texture.Texture);
                    }
                }

                for (int i = 0; i < _viewer.GetLength(0); i++)
                {
                    for (int j = 0; j < _viewer.GetLength(1); j++)
                    {
                        ITexture texture = Program.LevelMap.WorldMap[
                            _viewer[i, j].Position_x, _viewer[i, j].Position_y];
                        _viewer[i, j].Position_x = pos.Position_x + j - x;
                        _viewer[i, j].Position_y = pos.Position_y + i - y;
                        _viewer[i, j].Draw();
                    }
                }
            }
        }
    }
}
