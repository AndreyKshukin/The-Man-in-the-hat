using ConsoleGame.Interfaces;

namespace ConsoleGame.Engine
{
    public class ShapeString
    {
        private PointString[] _viewer;

        public ShapeString(ISize size)
        {
            int size_x = size.Size_x;
            int size_y = size.Size_y;

            _viewer = new PointString[size_y];

            int count = 0;
            string readStr = Resources.PlayerRunLeft1.Replace("\r\n", "");
            string[] str = new string[size_y];

            for (int i = 0; i < size_y; i++)
            {
                for (int j = 0; j < size_x; j++)
                {
                    str[i] += readStr[count];
                    count++;
                }

            }

            for (int i = 0; i < size_y; i++)
            {
                PointString sp = (20, 30, str[i]);
                _viewer[i] = sp;
            }
        }

        public ShapeString(int size_x, int size_y)
        {
            _viewer = new PointString[size_y];
            string str = "";
            for (int i = 0; i < size_x; i++)
            {
                str += '?';
            }
            for (int i = 0; i < size_y; i++)
            {
                PointString sp = (5, 5, str);
                _viewer[i] = sp;
            }
        }

        public void Clear()
        {
            int y = ((_viewer.Length % 2 == 0) ? -1 : 0)
                + (int)(_viewer.Length / 2);

            for (int i = 0; i < _viewer.Length; i++)
            {
                _viewer[i].Clear();
            }
        }

        public void UpdateShape(IPosition pos)
        {
            int y = ((_viewer.Length % 2 == 0) ? -1 : 0)
                + (int)(_viewer.Length / 2);

            for (int i = 0; i < _viewer.Length; i++)
            {
                _viewer[i].Clear();
            }

            for (int i = 0; i < _viewer.Length; i++)
            {
                _viewer[i].Position_x = pos.Position_x;
                _viewer[i].Position_y = pos.Position_y + i - y;
                _viewer[i].DrawString();
            }
        }

        public void SetShape(string[] shapeMask)
        {
            int size = _viewer.Length;

            for (int i = 0; i < size; i++)
            {
                _viewer[i].StrTexture = shapeMask[i];
            }
        }
    }
}
