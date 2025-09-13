//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class GridMoveCommand : Command
    {
        private AlienGrid pGrid;
        private Drum pDrum;

        public GridMoveCommand(GameObject _pGrid, Drum drum)
        {
            Debug.Assert(_pGrid != null);
            this.pGrid = (AlienGrid)_pGrid;
            Debug.Assert(drum != null);
            this.pDrum = drum;
        }

        public override void Execute(float deltaTime)
        {
            if (pDrum != null)
                pDrum.Update();

            float currentDelta = pGrid.GetDelta();

            float direction;
            if (currentDelta >= 0)
            {
                direction = 1.0f;
            }
            else
            {
                direction = -1.0f;
            }

            pGrid.SetDelta(pDrum.GetDeltaX() * direction);

            pGrid.MoveHorizontalGrid();
            AlienGrid.ResetCollisionFlag();

            TimerEventMan.Add(TimerEvent.Name.GridMove, this, pDrum.GetBeat());
        }
    }
}
