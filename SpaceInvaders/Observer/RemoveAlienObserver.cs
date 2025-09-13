//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class RemoveAlienObserver : ColObserver
    {
        public RemoveAlienObserver()
        {
            this.pAlien = null;
        }
        public RemoveAlienObserver(RemoveAlienObserver b)
        {
            Debug.Assert(b != null);
            this.pAlien = b.pAlien;
        }

        public override void Notify()
        {
            // Delete Alien
            Debug.WriteLine("RemoveAlienObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);


            this.pAlien = (AlienCategory)this.pSubject.pObjB;

            Debug.WriteLine(" Alien {0}  parent {1}", this.pAlien, this.pAlien.pParent);

            Debug.Assert(this.pAlien != null);

            if (pAlien.bMarkForDeath == false)
            {
                pAlien.bMarkForDeath = true;

                switch (this.pAlien.GetName())
                {
                    case GameObject.Name.Octopus:
                        ScoreManager.AddPoints(10);
                        break;
                    case GameObject.Name.Crab:
                        ScoreManager.AddPoints(20);
                        break;
                    case GameObject.Name.Squid:
                        ScoreManager.AddPoints(30);
                        break;
                    default:
                        break;
                }

                //   Delay
                RemoveAlienObserver pObserver = new RemoveAlienObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
            else
            {
                pAlien.bMarkForDeath = true;
            }

            TimerEventMan.Add(TimerEvent.Name.AlienDestroy, new AlienDestroyCommand(pAlien.x, pAlien.y, TimerEvent.Name.AlienDestroy), 0.05f);

        }
        public override void Execute()
        {
            Debug.WriteLine(" Alien {0}  parent {1}", this.pAlien, this.pAlien.pParent);

            GameObject pA = (GameObject)this.pAlien;
            GameObject pB = (GameObject)IteratorForwardComposite.GetParent(pA);
            GameObject pC = (GameObject)IteratorForwardComposite.GetParent(pB);


            // Alien
            if (pA.GetNumChildren() == 0)
            {
                pA.Remove();
            }

            // Column 
            if (pB.GetNumChildren() == 0)
            {
                pB.Remove();
            }

        }
        private bool privCheckParent(GameObject pObj)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(pObj);
            if (pGameObj == null)
            {
                return true;
            }

            return false;
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

        private GameObject pAlien;
    }
}

// --- End of File ---
