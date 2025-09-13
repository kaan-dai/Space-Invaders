//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class GridObserver : ColObserver
    {
        public GridObserver()
        {

        }
        override public void Notify()
        {
            Debug.WriteLine("Grid_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            // OK do some magic
            AlienGrid pGrid = (AlienGrid)this.pSubject.pObjA;

            WallCategory pWall = (WallCategory)this.pSubject.pObjB;

           


            if (pWall.GetCategoryType() == WallCategory.Type.Right || pWall.GetCategoryType() == WallCategory.Type.Left)
            {
                pGrid.SetDelta(-pGrid.GetDelta());
            }
            else
            {
                Debug.Assert(false);
            }

            pGrid.MoveVerticalGrid();

        }

        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.GridObserver;
        }


    }
}

// --- End of File ---
