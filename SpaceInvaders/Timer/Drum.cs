//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace SE456
{
    public class Drum
    {
        public Drum(AlienGrid grid, float startDeltaTime, float endDeltaTime, float startDeltaX, float endDeltaX)
        {
            Debug.Assert(grid != null);
            this.pGrid = grid;
            this.startDeltaTime = startDeltaTime;
            this.endDeltaTime = endDeltaTime;
            this.startDeltaX = startDeltaX;
            this.endDeltaX = endDeltaX;

            this.currentBeat = startDeltaTime;
            this.currentDeltaX = startDeltaX;
        }

        public void Update()
        {
            int alienCount = GetAlienCount();
            if (alienCount < 0)
            {
                alienCount = 0;
            }
            if (alienCount > maxAlienCount)
            {
                alienCount = maxAlienCount;
            }

            float ratio = (float)alienCount / maxAlienCount;

            this.currentBeat = endDeltaTime + (startDeltaTime - endDeltaTime) * ratio;

            this.currentDeltaX = endDeltaX + (startDeltaX - endDeltaX) * ratio;

        }

        private int GetAlienCount()
        {
            int count = 0;
            IteratorForwardComposite it = new IteratorForwardComposite(pGrid);

            for (it.First(); !it.IsDone(); it.Next())
            {
                GameObject alien = (GameObject)it.Curr();
                if (alien.type == Component.Container.LEAF)
                {
                    count++;
                }
                
            }
            return count;
        }

        public float GetBeat()
        {
            return this.currentBeat;
        }

        public float GetDeltaX()
        {
            return this.currentDeltaX;
        }
        public bool IsEmpty()
        {
            return GetAlienCount() == 0;      
        }

        //---------Data----------

        private float startDeltaTime;
        private float endDeltaTime;
        private float startDeltaX;
        private float endDeltaX;
        private float currentBeat;
        private float currentDeltaX;
        private AlienGrid pGrid;
        private const int maxAlienCount = 55;

    }
}
