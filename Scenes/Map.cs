using ConsoleGame.Interfaces;
using ConsoleGame.Masks;
using ConsoleGame.Materials;

namespace ConsoleGame.Scenes
{
    public class Map : ISize
    {
        public int Size_x { get; set; }
        public int Size_y { get; set; }

        public SolidMask SolidMask;

        private Material[,] _worldMap;
        public Material[,] WorldMap
        { get => _worldMap; }

        /// <summary>
        /// Загружает прямоугольную карту
        /// </summary>
        public Map(string map)
        {
            string str = map.Replace("\r\n", ">");
            bool firstValue = true;

            Size_x = 0;
            Size_y = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '>')
                {
                    Size_y++;
                    firstValue = false;
                }

                if (firstValue)
                    Size_x++;
            }

            _worldMap = new Material[Size_x, Size_y];

            int x = 0;
            int y = 0;
            
            Material valuePoint;

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '.':
                        valuePoint = new Space();
                        _worldMap[x, y] = valuePoint;
                        x++;
                        break;
                    case '█':
                        valuePoint = new Wall();
                        _worldMap[x, y] = valuePoint;
                        x++;
                        break;
                    case '♥':
                        valuePoint = new Ground();
                        _worldMap[x, y] = valuePoint;
                        x++;
                        break;
                    case '>':
                        y++;
                        x = 0;
                        break;
                    default:
                        valuePoint = new UnknownMaterial();
                        _worldMap[x, y] = valuePoint;
                        x++;
                        break;
                }
            }

            SolidMask = new SolidMask(this);
            Render render = new Render(this);
        }

        public virtual void RunGamePlay()
        {
        }
    }

}