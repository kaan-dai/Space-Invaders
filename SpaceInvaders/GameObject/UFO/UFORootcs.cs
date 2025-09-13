//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class UFORoot : Composite
    {
        public UFORoot(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
           : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.pUFO = new UFO(GameObject.Name.UFO, SpriteGame.Name.UFO, posX, posY);
            this.Add(pUFO);

            this.poColObj.pColSprite.SetColor(1, 0, 0);
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitUFORoot(this);
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public void MoveUFOHorizontal()
        {
            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += this.deltaX;

                pNode = pFor.Next();
            }
        }

        // Data: ---------------
        private UFO pUFO;
        public float deltaX = 2.0f;
    }
}

// --- End of File ---