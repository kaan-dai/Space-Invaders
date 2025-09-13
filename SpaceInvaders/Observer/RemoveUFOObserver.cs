//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using SE456.SE456;
using System;
using System.Diagnostics;

namespace SE456
{
    class RemoveUFOObserver : ColObserver
    {
        public RemoveUFOObserver()
        {
            this.pUFO = null;
        }
        public RemoveUFOObserver(RemoveUFOObserver u)
        {
            Debug.Assert(u != null);
            this.pUFO = u.pUFO;
        }

        public override void Notify()
        {
            // Delete Alien
            Debug.WriteLine("RemoveUFOObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);


            this.pUFO = (UFO)this.pSubject.pObjB;

            Debug.WriteLine(" UFO {0}  parent {1}", this.pUFO, this.pUFO.pParent);

            Debug.Assert(this.pUFO != null);

            if (pUFO.bMarkForDeath == false)
            {
                pUFO.bMarkForDeath = true;


                //   Delay
                RemoveUFOObserver pObserver = new RemoveUFOObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
            else
            {
                pUFO.bMarkForDeath = true;
            }

            UFOMoveCommand.isDestroyed = true;
            UFOMoveCommand.isReady = false;
            TimerEventMan.Add(TimerEvent.Name.UFODestroy, new UFODestroyCommand(pUFO.x, pUFO.y), 0.05f);

        }
        public override void Execute()
        { 


            this.pUFO.Remove();

        }
        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.RemoveAlienObserver;
        }



        // -------------------------------------------
        // data:
        // -------------------------------------------

        private GameObject pUFO;
    }
}

// --- End of File ---
