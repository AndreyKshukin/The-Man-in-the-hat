using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Materials
{
    public class UnknownMaterial : Material
    {
        public UnknownMaterial()
        {
            Texture = '_';
            IsSolid = true;
        }
    }
}
