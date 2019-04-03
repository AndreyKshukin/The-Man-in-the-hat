using System;
using ConsoleGame.Masks;
using ConsoleGame.Materials;
using ConsoleGame.Scenes;

namespace ConsoleGame
{
    public class Render
    {
        public Render(Map levelMap)
        {
            for (int i = 0; i < levelMap.WorldMap.GetLength(1); i++)
            {
                for (int j = 0; j < levelMap.WorldMap.GetLength(0); j++)
                {
                    levelMap.SolidMask.Map[j, i] = levelMap.WorldMap[j, i];
                    Console.Write(levelMap.WorldMap[j, i].Texture);
                }
            }
        }
    }
}