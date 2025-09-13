//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class SpriteBase : DLink
    {
        public SpriteBase()
        : base()
        {
            this.pBackSpriteNode = null;
        }

        abstract public void Render();
        abstract public void Update();

        protected override void baseWash()
        {
            base.baseWash();
        }
        protected override void baseDump()
        {
            base.baseDump();
        }

        public SpriteNode GetSpriteNode()
        {
            Debug.Assert(this.pBackSpriteNode != null);
            return this.pBackSpriteNode;
        }
        public void SetSpriteNode(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSpriteNode = pSpriteBatchNode;
        }

        // Data: -------------------------------------------

        private SpriteNode pBackSpriteNode;
    }
}

// --- End of File ---
