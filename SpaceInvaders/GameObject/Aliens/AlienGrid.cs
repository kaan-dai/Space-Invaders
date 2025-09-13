//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class AlienGrid : Composite
    {
        public AlienGrid()
            : base()
        {
            this.name = Name.AlienGrid;

            this.poColObj.pColSprite.SetColor(0, 1, 0);

            this.delta_x = 4.0f;
            this.delta_y = 20.0f;
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an AlienGrid
            // Call the appropriate collision reaction
            if (!hasCollided)
            {
                other.VisitGrid(this);
                hasCollided = true;

            }
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // AlienGrid vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs AlienGrid
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }



        public override void Update()
        {

            base.BaseUpdateBoundingBoxColumnGrid(this);
            base.Update();
        }

        public void MoveHorizontalGrid()
        {

            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += this.delta_x;

                pNode = pFor.Next();
            }
        }

        public void MoveVerticalGrid()
        {

            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.y -= this.delta_y;

                pGameObj.x += this.delta_x;

                pNode = pFor.Next();
            }
        }

        public float GetDelta()
        {
            return this.delta_x;
        }

        public void SetDelta(float inDelta)
        {
            this.delta_x = inDelta;
        }

        public static void ResetCollisionFlag()
        {
            hasCollided = false;
        }

        public static void SetHitLeft(bool hit)
        {
            hitLeft = hit;
        }
        public static bool GetHitLeft()
        {
            return hitLeft;
        }

        // Data: ---------------
        private float delta_x;
        private float delta_y;
        private static bool hasCollided = false;
        private static bool hitLeft = true;

    }

}

// --- End of File ---
