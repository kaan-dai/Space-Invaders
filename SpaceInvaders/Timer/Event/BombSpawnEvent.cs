//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Windows.Documents;

namespace SE456
{
    class BombSpawnEvent : Command
    {
        public BombSpawnEvent(Random pRandom, float x, float y)
        {
            this.pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            Debug.Assert(this.pSB_Aliens != null);

            this.pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.x = x;
            this.y = y;

            this.pRandom = pRandom;
        }

        override public void Execute(float deltaTime)
        {
            Bomb pBomb = null;
            // Create Bomb

            int bombType = pRandom.Next(0, 3);

            switch (bombType)
            {
                case 0:
                    pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombStraight, new FallStraight(), x, y);
                    break;
                case 1:
                    pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombDagger, new FallDagger(), x, y);
                    break;
                case 2:
                    pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombZigZag, new FallZigZag(), x, y);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            Debug.Assert(pBomb != null);

            pBomb.ActivateCollisionSprite(this.pSB_Boxes);
            pBomb.ActivateSprite(this.pSB_Aliens);

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pBombRoot.Add(pBomb);


        }

        //------------Data-----------------
        GameObject pBombRoot;
        SpriteBatch pSB_Aliens;
        SpriteBatch pSB_Boxes;
        Random pRandom;
        float x;
        float y;
    }
}

// --- End of File ---
