using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace SE456
{
    public class BombSpawnManagerCommand : Command
    {
        public BombSpawnManagerCommand(GameObject alienGrid, Random random)
        {
            Debug.Assert(alienGrid != null);
            Debug.Assert(random != null);
            this.pAlienGrid = alienGrid;
            this.pRandom = random;
        }

        public override void Execute(float deltaTime)
        {

            int columnCount = 0;
            IteratorForwardComposite it = new IteratorForwardComposite(pAlienGrid);

            for (it.First(); !it.IsDone(); it.Next())
            {
                GameObject pObject = (GameObject)it.Curr();

                if (pObject.GetName().Equals(GameObject.Name.AlienColumn))
                {
                    columnCount++;
                }
            }

            if (columnCount == 0)
            {
                return;
            }

            int target = pRandom.Next(0, columnCount);
            int current = 0;
            GameObject chosenColumn = null;

            for (it.First(); !it.IsDone(); it.Next())
            {
                GameObject pObject = (GameObject)it.Curr();
                if (pObject.GetName().Equals(GameObject.Name.AlienColumn))
                {
                    if (current == target)
                    {
                        chosenColumn = pObject;
                        break;
                    }
                    current++;
                }
            }

            if (chosenColumn != null)
            {
                GameObject bottomAlien = null;
                float minY = float.MaxValue;

                IteratorForwardComposite itCol = new IteratorForwardComposite(chosenColumn);
                for (itCol.First(); !itCol.IsDone(); itCol.Next())
                {
                    GameObject alien = (GameObject)itCol.Curr();

                    if (alien.y < minY)
                    {
                        minY = alien.y;
                        bottomAlien = alien;
                    }
                }

                if (bottomAlien != null)
                {

                    float spawnX = bottomAlien.x;
                    float spawnY = bottomAlien.y - bottomAlien.GetBoundingBoxHeight();

                    Bomb pBomb = null;

                    int bombType = pRandom.Next(0, 3);

                    switch (bombType)
                    {
                        case 0:
                            pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombStraight, new FallStraight(), spawnX, spawnY);
                            break;
                        case 1:
                            pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombDagger, new FallDagger(), spawnX, spawnY);
                            break;
                        case 2:
                            pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombZigZag, new FallZigZag(), spawnX, spawnY);
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                    Debug.Assert(pBomb != null);

                    SpriteBatch SB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
                    SpriteBatch SB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

                    pBomb.ActivateSprite(SB_Aliens);
                    pBomb.ActivateCollisionSprite(SB_Boxes);

                    GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
                    Debug.Assert(pBombRoot != null);

                    pBombRoot.Add(pBomb);
                }
            }

            float nextDelay = ((float)pRandom.NextDouble() * 1.5f + 0.5f) / ScenePlay.Level;
            TimerEventMan.Add(TimerEvent.Name.BombSpawn, this, nextDelay);
        }

        //---------------------Data--------------------
        private GameObject pAlienGrid;
        private Random pRandom;
    }
}
