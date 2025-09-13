//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{

    abstract public class ColObserver : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            SoundObserver,
            GridObserver,
            RemoveAlienObserver,
            ShipReadyObserver,
            ShipRemoveMissileObserver,
            ShipMoveObserver,
            BombObserver,
            RemoveBrickObserver,
            RemoveMissileObserver,
            RemoveBombObserver,
            ShipDeathObserver,
            Uninitialized
        }
        public abstract void Notify();

        // WHY not add a Command pattern into our Observer!
        public virtual void Execute()
        {
            // default implementation
        }

        override public void Wash()
        {
            Debug.Assert(false);
        }

        public ColSubject pSubject;
    }

}

// --- End of File ---
