//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class Crab : AlienCategory
    {
        public Crab(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Crab, spriteName, posX, posY)
        {
       
        }


        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Crab
            // Call the appropriate collision reaction            
            other.VisitCrab(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // Crab vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Crab
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Crab
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void Update()
        {
            base.Update();
        }

        // Data: ---------------
        
    }
}

// --- End of File ---
