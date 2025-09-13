//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class Octopus : AlienCategory
    {
        public Octopus(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Octopus, spriteName, posX, posY)
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Octopus
            // Call the appropriate collision reaction            
            other.VisitOctopus(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // Octopus vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Octopus
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Octopus
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
