using System;
using System.Diagnostics;

namespace SE456
{

    using System;
    using System.Diagnostics;
    using System.Windows.Controls;

    namespace SE456
    {
        class UFODestroyCommand : Command
        {
            public UFODestroyCommand(float x , float y)
            {
                this.x = x;
                this.y = y;
            }

            public override void Execute(float deltaTime)
            {
                if (firstTime)
                {
                    Random random = new Random();
                    int points = random.Next(1, 4) * 100;
                    ScoreManager.AddPoints(points);

                    SpriteBatchMan.Find(SpriteBatch.Name.Aliens).Attach(SpriteGameMan.Add(SpriteGame.Name.UFODestroy, Image.Name.UFODestroy, x, y, 39.0f, 25.0f, new Azul.Color(1, 0, 0)));
                    firstTime = false;
                    TimerEventMan.Add(TimerEvent.Name.UFODestroy, this, 0.3f);

                    Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, string.Join(" ", points.ToString()), Glyph.Name.SpaceInvaders, x + 25, y);
                    pFont.SetColor(1, 0 , 0);
                    pFont.poSpriteFont.sx = 3.0f;
                    pFont.poSpriteFont.sy = 3.0f;
                }
                else
                {

                    SpriteGameMan.Remove(SpriteGameMan.Find(SpriteGame.Name.UFODestroy));
                    firstTime = true;

                    UFORoot UFORoot = (UFORoot)GameObjectNodeMan.Find(GameObject.Name.UFORoot);
                    Component UFO = (GameObject)IteratorForwardComposite.GetChild(UFORoot);

                    if (UFORoot != null)
                    {
                        if(UFO != null)
                        {
                            UFORoot.Remove(UFO);
                        }
                        int x;
                        if(new Random().Next(0,2) == 0)
                        {
                            x = -60;
                        }
                        else
                        {
                            x = 730;
                            UFORoot.deltaX *= -1;

                        }

                        UFO newUFO = new UFO(GameObject.Name.UFO, SpriteGame.Name.UFO, x, 650);
                        newUFO.ActivateSprite(SpriteBatchMan.Find(SpriteBatch.Name.Aliens));
                        newUFO.ActivateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));
                        UFORoot.Add(newUFO);

                        UFOMoveCommand.isDestroyed = false;
                        UFOMoveCommand.isReady = false;

                        UFOMoveCommand pUFOCmd = new UFOMoveCommand();
                        TimerEventMan.Add(TimerEvent.Name.UFOMove, pUFOCmd, new Random().Next(20,30));

                        FontMan.Find(Font.Name.TestMessage).UpdateMessage(" ");
                    }
                }

            }

            // Data: ---------------
            private float x;
            private float y;
            private bool firstTime = true;

        }

    }

    // --- End of File ---

}
