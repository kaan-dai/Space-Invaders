
using System;
using System.Diagnostics;

namespace SE456
{
    class BombDestroyCommand : Command
    {
        public BombDestroyCommand(float x, float y, TimerEvent.Name name)
        {
            this.name = name;
            // initialized the sprite animation is attached to
            this.x = x;
            this.y = y;

        }

        public override void Execute(float deltaTime)
        {
            if (firstTime)
            {
                SpriteBatchMan.Find(SpriteBatch.Name.Bombs).Attach(SpriteGameMan.Add(SpriteGame.Name.BombDestroy, Image.Name.BombDestroy, x, y, 12.0f, 16.0f));
                firstTime = false;
                TimerEventMan.Add(this.name, this, 0.3f);
            }
            else
            {
                SpriteGameMan.Remove(SpriteGameMan.Find(SpriteGame.Name.BombDestroy));
                firstTime = true;
            }

        }

        // Data: ---------------
        private TimerEvent.Name name;
        private float x;
        private float y;
        private bool firstTime = true;
    }

}

// --- End of File ---
