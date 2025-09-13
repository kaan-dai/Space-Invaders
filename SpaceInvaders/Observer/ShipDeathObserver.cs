using System;
using System.Diagnostics;

namespace SE456
{
    class ShipDeathObserver : ColObserver
    {
        public override void Notify()
        {
            Ship pShip = (Ship)this.pSubject.pObjB;
            Debug.Assert(pShip != null);


            if (Ship.shipLife > 0)
            {
                Ship.shipLife--;

                SpriteGameMan.Remove(SpriteGameMan.Find(SpriteGame.Name.ReservedShip));

                Font lifeFont = FontMan.Find(Font.Name.Life);
                if (lifeFont != null)
                {
                    lifeFont.UpdateMessage(Ship.shipLife.ToString());
                }

                

                if (ShipDeathObserver.useFirstDeathSprite)
                {
                    pShip.SetSpriteDeath(SpriteGame.Name.ShipDeath1);
                    useFirstDeathSprite = false;
                }
                else
                {
                    pShip.SetSpriteDeath(SpriteGame.Name.ShipDeath2);
                    useFirstDeathSprite = true;
                }

                TimerEventMan.PauseUpdate(2.0f);

                pShip.SetState(ShipMan.MissileState.Flying);
                pShip.SetState(ShipMan.MoveState.DontMove);

                TimerEventMan.Add(TimerEvent.Name.ShipDeath, new ShipDeathCommand(pShip), 2.0f);


            }

            else
                {

                if (ScoreManager.score > ScoreManager.highScore)
                {
                    ScoreManager.highScore = ScoreManager.score;
                }

                Font highScoreFont = FontMan.Find(Font.Name.HighScoreNum);
                if (highScoreFont != null)
                {
                    highScoreFont.UpdateMessage(ScoreManager.highScore.ToString());
                }



                TimerEventMan.Add(TimerEvent.Name.ChangeScene, new ChangeSceneCommand(SceneContext.Scene.Over), 0.0f);
                }
            
        }
        public override void Dump() { }

        public override System.Enum GetName()
        {
            return ColObserver.Name.ShipDeathObserver;
        }

        private static bool useFirstDeathSprite = true;

    }
}
