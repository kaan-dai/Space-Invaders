//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class WallRight : WallCategory
    {
        public WallRight(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, Type.Right)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetColor(1, 1, 0);
        }

        ~WallRight()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallRight(this);
        }
        public override void Update()
        {
            // Go to first child
            base.Update();
        }


        public override void VisitGrid(AlienGrid a)
        {
            // AlienGroup vs WallRight
            Debug.WriteLine("\ncollide: {0} with {1}", this, a);
            Debug.WriteLine("               --->DONE<----");

            ColPair pColPair = ColPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);
            if(AlienGrid.GetHitLeft())
            {
                pColPair.SetCollision(a, this);
                pColPair.NotifyListeners();
                AlienGrid.SetHitLeft(false);

            }
        }

        public override void VisitBomb(Bomb b)
        {
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBombRoot(BombRoot b)
        {
            // BombRoot vs MissileGroup
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(b, pGameObj);
        }

        // Data: ---------------


    }
}

// --- End of File ---
