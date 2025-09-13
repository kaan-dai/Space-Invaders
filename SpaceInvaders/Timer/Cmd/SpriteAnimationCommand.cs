//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class SpriteAnimationCommand : Command
    {
        private SpriteGame pSprite;
        private SLinkMan poSLinkMan;
        private Iterator pIt;
        private Drum pDrum;

        public SpriteAnimationCommand(SpriteGame.Name spriteName, Drum drum)
        {
            Debug.Assert(drum != null);
            this.pDrum = drum;

            // Find the sprite from the SpriteGame manager
            this.pSprite = SpriteGameMan.Find(spriteName);
            Debug.Assert(this.pSprite != null);

            this.poSLinkMan = new SLinkMan();
            Debug.Assert(this.poSLinkMan != null);

            // Get the iterator for the image list
            this.pIt = this.poSLinkMan.GetIterator();
            Debug.Assert(this.pIt != null);
        }

        public SpriteAnimationCommand(SpriteGame.Name spriteName)
        {
            // initialized the sprite animation is attached to
            this.pSprite = SpriteGameMan.Find(spriteName);
            Debug.Assert(this.pSprite != null);

            this.poSLinkMan = new SLinkMan();
            Debug.Assert(this.poSLinkMan != null);

            // need to keep iterator for state
            this.pIt = this.poSLinkMan.GetIterator();
            Debug.Assert(this.pIt != null);
        }
        public void Attach(Image.Name imageName)
        {
            // Find the image
            Image pImage = ImageMan.Find(imageName);
            Debug.Assert(pImage != null);

            // Create a new node for the image
            ImageNode pImageHolder = new ImageNode(pImage);
            Debug.Assert(pImageHolder != null);

            // Add it to the front of the image list
            this.poSLinkMan.AddToFront(pImageHolder);

            // Update the iterator
            this.pIt = this.poSLinkMan.GetIterator();
            Debug.Assert(this.pIt != null);
        }

        public override void Execute(float deltaTime)
        {
            if (pDrum != null)
                pDrum.Update();

            // If we've reached the end of the list, start over
            if (this.pIt.IsDone())
            {
                this.pIt.First();
            }

            // Get the current image node
            ImageNode pImageNode = (ImageNode)this.pIt.Current();
            Debug.Assert(pImageNode != null);

            // Advance for next time
            this.pIt.Next();

            // Swap the sprite's image
            this.pSprite.SwapImage(pImageNode.pImage);

            TimerEventMan.Add(TimerEvent.Name.SpriteAnimation, this, pDrum.GetBeat());
        }
    }
}
