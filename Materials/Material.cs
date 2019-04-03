using System;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Materials
{
    public abstract class Material : ITexture, IIsSolid
    {
        private char _texture;
        public char Texture { get => _texture; protected set { _texture = value; } }
        private bool _isSolid;
        public bool IsSolid{get =>_isSolid; protected set { _isSolid = value; } }

        public void SetSolidMask(int width, int hight)
        {
            Program.LevelMap.SolidMask.SetSolid(width, hight,this);
        }

        public virtual void SetSolidMask()
        {
        }
    }
}