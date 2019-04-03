using ConsoleGame.Interfaces;

namespace ConsoleGame.Masks
{
    public class SolidMask : Mask
    {
        public IIsSolid[,] Map { get; set; }

        public SolidMask(ISize size)
        {
            Map = new IIsSolid[size.Size_x, size.Size_y];
        }

        public SolidMask(int width, int hight)
        {
            Map = new IIsSolid[width, hight];
        }

        public IIsSolid GetSolid(int width, int hight)
        {
            return Map[width, hight];
        }

        public void SetSolid(int width, int hight, IIsSolid solid)
        {
            Map[width, hight] = solid;
        }
    }
}
