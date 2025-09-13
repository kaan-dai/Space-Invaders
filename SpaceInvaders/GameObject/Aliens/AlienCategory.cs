//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class AlienCategory : Leaf
    {
        public enum Type
        {
            Squid,
            Crab,
            Octopus,

            AlienColumn,
            AlienGrid,

            Unitialized
        }

        protected AlienCategory(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(gameName,spriteName,_x,_y)
        {

        }
    }
}

// --- End of File ---
