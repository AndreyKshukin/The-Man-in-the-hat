using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Materials
{
    public class Wall : Material
    {
        public Wall()
        {
            Texture = '█';
            IsSolid = true;
        }
    }
}
