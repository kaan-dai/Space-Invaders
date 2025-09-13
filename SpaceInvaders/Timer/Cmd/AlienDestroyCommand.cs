
using System;
using System.Diagnostics;

namespace SE456
{
    class AlienDestroyCommand : Command
    {
        public AlienDestroyCommand(float x, float y, TimerEvent.Name name)
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
                SpriteBatchMan.Find(SpriteBatch.Name.Aliens).Attach(SpriteGameMan.Add(SpriteGame.Name.AlienDestroy, Image.Name.AlienDestroy, x, y, 36.0f, 25.0f));
                firstTime = false;
                TimerEventMan.Add(this.name, this, 0.3f);
            }
            else
            {
                SpriteGameMan.Remove(SpriteGameMan.Find(SpriteGame.Name.AlienDestroy));
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
