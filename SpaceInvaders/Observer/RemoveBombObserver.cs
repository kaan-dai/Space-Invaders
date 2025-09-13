//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SE456
{
    class RemoveBombObserver : ColObserver
    {
        public RemoveBombObserver()
        {
            this.pBomb = null;
        }
        public RemoveBombObserver(RemoveBombObserver b)
        {
            this.pBomb = b.pBomb;
        }
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveBombObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.pBomb = this.pSubject.pObjA;
            if (this.pBomb.GetType() == typeof(Bomb))
            {
                this.pBomb = (Bomb)pBomb;
            }
            else
            {
                this.pBomb = (Bomb)this.pSubject.pObjB;
            }

            Debug.Assert(this.pBomb != null);

            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                //   Delay
                RemoveBombObserver pObserver = new RemoveBombObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }

            TimerEventMan.Add(TimerEvent.Name.BombDestroy, new BombDestroyCommand(pBomb.x, pBomb.y, TimerEvent.Name.BombDestroy), 0.05f);


        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.pBomb.Remove();
        }

        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.RemoveBombObserver;
        }

        // --------------------------------------
        // data:
        // --------------------------------------

        private GameObject pBomb;
    }
}

// --- End of File ---
