using ConsoleGame.Interfaces;

namespace ConsoleGame.Physics
{
    public class BoxCollider : IIsSolid
    {
        public bool IsSolid { get; set; }

        public bool CheckRight(int pos_x, int pos_y, ISize size)
        {
            bool checkSolid = false;
            int x = pos_x + size.Size_x / 2;
            int y = pos_y + size.Size_y / 2;

            if (x < 150)
            {
                for (int i = 0; i < size.Size_y; i++)
                {
                    if (Program.LevelMap.SolidMask.GetSolid(x, y - i).IsSolid)
                    {
                        checkSolid = true;
                        i = size.Size_y;
                    }
                }
            }
            else
                checkSolid = true;

            return checkSolid;
        }

        public bool CheckLeft(int pos_x, int pos_y, ISize size)
        {
            bool checkSolid = false;
            int x = pos_x - size.Size_x / 2;
            int y = pos_y + size.Size_y / 2;

            if (x >= 0)
            {
                for (int i = 0; i < size.Size_y; i++)
                {
                    if (Program.LevelMap.SolidMask.GetSolid(x, y - i).IsSolid)
                    {
                        checkSolid = true;
                        i = size.Size_y;
                    }
                }
            }
            else
                checkSolid = true;

            return checkSolid;
        }

        public bool CheckUp(int pos_x, int pos_y, ISize size)
        {
            bool checkSolid = false;
            int x = pos_x - size.Size_x / 2;
            int y = pos_y - size.Size_y / 2;

            if (y >= 0)
            {
                for (int i = 0; i < size.Size_x; i++)
                {
                    if (Program.LevelMap.SolidMask.GetSolid(x + i, y).IsSolid)
                    {
                        checkSolid = true;
                        i = size.Size_x;
                    }
                }
            }
            else
                checkSolid = true;

            return checkSolid;
        }

        public bool CheckDown(int pos_x, int pos_y, ISize size)
        {
            bool checkSolid = false;
            int x = pos_x - size.Size_x / 2;
            int y = pos_y + size.Size_y / 2;

            if (y < 50)
            {
                for (int i = 0; i < size.Size_x; i++)
                {
                    if (Program.LevelMap.SolidMask.GetSolid(x + i, y).IsSolid)
                    {
                        checkSolid = true;
                        i = size.Size_x;
                    }
                }
            }
            else
                checkSolid = true;

            return checkSolid;
        }

        public void SetSolidMask(int width, int hight, ISize size)
        {
            int x = width + size.Size_x / 2;
            int y = hight + size.Size_y / 2;

            for (int i = 0; i < size.Size_x; i++)
            {
                Program.LevelMap.SolidMask.SetSolid(x - i, y, this);
            }

            for (int i = 1; i < size.Size_y; i++)
            {
                Program.LevelMap.SolidMask.SetSolid(x, y - i,this);
            }

            x -= size.Size_x - 1;
            y -= size.Size_y - 1;

            for (int i = 0; i < size.Size_x - 1; i++)
            {
                Program.LevelMap.SolidMask.SetSolid(x + 1, y, this);
            }

            for (int i = 1; i < size.Size_y - 1; i++)
            {
                Program.LevelMap.SolidMask.SetSolid(x, y + i, this);
            }
        }

        public bool GetSolidMask(int width, int hight, ISize size)
        {
            bool checkSolid = false;

            int x = width + size.Size_x / 2;
            int y = hight + size.Size_y / 2;

            for (int i = 0; i < size.Size_x; i++)
            {
                if (Program.LevelMap.SolidMask.GetSolid(x - i, y).IsSolid)
                {
                    checkSolid = true;
                    i = size.Size_x;
                }
            }

            if (!checkSolid)
            {
                for (int i = 1; i < size.Size_y; i++)
                {
                    if (Program.LevelMap.SolidMask.GetSolid(x, y - i).IsSolid)
                    {
                        checkSolid = true;
                        i = size.Size_y;
                    }
                }
            }

            x -= size.Size_x - 1;
            y -= size.Size_y - 1;


            if (!checkSolid)
            {
                for (int i = 0; i < size.Size_x - 1; i++)
                {
                    if (Program.LevelMap.SolidMask.GetSolid(x + 1, y).IsSolid)
                    {
                        checkSolid = true;
                        i = size.Size_x;
                    }
                }
            }

            if (!checkSolid)
            {
                for (int i = 1; i < size.Size_y - 1; i++)
                {
                    if (Program.LevelMap.SolidMask.GetSolid(x, y + i).IsSolid)
                    {
                        checkSolid = true;
                        i = size.Size_y;
                    }
                }
            }

            return checkSolid;
        }
    }
}
