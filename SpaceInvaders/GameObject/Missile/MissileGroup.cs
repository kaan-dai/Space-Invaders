//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class MissileGroup : Composite
    {
        public MissileGroup()
            : base()
        {
            this.name = Name.MissileGroup;

            this.poColObj.pColSprite.SetColor(0, 0, 1);
        }

        ~MissileGroup()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an MissileGroup
            // Call the appropriate collision reaction            
            other.VisitMissileGroup(this);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }



        // Data: ---------------


    }
}

// --- End of File ---

