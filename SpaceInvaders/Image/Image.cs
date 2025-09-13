//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class Image : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {

            SquidA,
            SquidB,
            CrabA,
            CrabB,
            OctopusA,
            OctopusB,

            Missile,
            Ship,


            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,

            Shields,
            ShieldRoot,
            ShieldGrid,
            ShieldColumn_0,
            ShieldBrick,

            BombRoot,
            Bomb,
            BombStraightA,
            BombStraightB,
            BombZigZagA,
            BombZigZagB,
            BombDaggerA,
            BombDaggerB,
            BombCrossA,
            BombCrossB,
            BombStraight,

            AlienDestroy,
            BombDestroy,

            ShipDeath1,
            ShipDeath2,

            UFO,
            UFODestroy,

            NullObject,
            HotPink,
            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------
        public Image()
            : base()
        {
            this.mName = Name.Uninitialized;
            this.pTexture = null;

            this.poRect = new Azul.Rect();
            Debug.Assert(this.poRect != null);
        }

        //------------------------------------
        // Methods
        //------------------------------------
        public void Set(Name _name,
                        Texture _pSrcTexture,
                        float _x,
                        float _y,
                        float _w,
                        float _h)
        {
            Debug.Assert(_pSrcTexture != null);
            Debug.Assert(_name != Image.Name.Uninitialized);

            this.pTexture = _pSrcTexture;

            // Remember the allocation was already made in constructor
            // so don't remove... replace the data
            Debug.Assert(this.poRect != null);
            this.poRect.Set(_x, _y, _w, _h);

            this.mName = _name;
        }
        public Azul.Texture GetAzulTexture()
        {
            return this.pTexture.GetAzulTexture();
        }

        public Azul.Rect GetAzulRect()
        {
            return this.poRect;
        }

        //------------------------------------
        // Override
        //------------------------------------
        override public Enum GetName()
        {
            return this.mName;
        }

        override public void Wash()
        {
            Debug.Assert(this.poRect != null);
            this.poRect.Clear();

            this.mName = Name.Uninitialized;
            this.pTexture = null;

            base.baseWash();
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   Name: {0} ({1})", this.GetName(), this.GetHashCode());
            if (this.pTexture == null)
            {
                Debug.WriteLine("      Texture: null");
            }
            else
            {
                Debug.WriteLine("      Texture: {0} ({1})", this.pTexture.GetName(), this.pTexture.GetHashCode());
            }
            Debug.WriteLine("      Rect: [{0} {1} {2} {3}] ", this.poRect.x, this.poRect.y, this.poRect.width, this.poRect.height);

            base.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public Name mName;
        public Azul.Rect poRect;
        public Texture pTexture;
    }
}

// --- End of File ---