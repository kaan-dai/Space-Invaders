//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class UFO : Leaf
    {

        public UFO(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
         : base(name, spriteName, posX, posY)
        {
        }

        public override void Update()
        {

            if ((this.x == spawnX || this.x == spawnX + 1 ))
            {
                TimerEventMan.Add(TimerEvent.Name.BombSpawn, new BombSpawnEvent(new Random(), this.x, this.y), 0.0f);
            }

            base.Update();
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitUFO(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        //----------------Data------------
        private static float spawnX = new Random().Next(120, 520);
       
    }

    
}

// --- End of File ---
