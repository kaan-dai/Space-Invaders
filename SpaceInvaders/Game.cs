//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class SpaceInvaders : Azul.Game
    {

        SceneContext pSceneContext = null;


        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Final");
            this.SetWidthHeight(672, 768);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //-----------------------------------
            // Load Managers
            //-----------------------------------

            Simulation.Create();
            TextureMan.Create();
            ImageMan.Create();
            SpriteGameMan.Create();
            SpriteBatchMan.Create();
            SpriteBoxMan.Create();
            TimerEventMan.Create();
            SpriteGameProxyMan.Create();
            GameObjectNodeMan.Create();
            ColPairMan.Create();
            GlyphMan.Create();
            FontMan.Create();
            GhostMan.Create();

            pSceneContext = new SceneContext();
        }
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------

        public override void Update()
        {
            SceneState currentState = pSceneContext.GetState();

            if (currentState.GetType() == typeof(SceneOver) && Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_Q))
            {
                this.Reset();
                pSceneContext.SetState(SceneContext.Scene.Select);
            }

            if (currentState.GetType() == typeof(SceneSelect) && Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_P))
            {
                pSceneContext.SetState(SceneContext.Scene.Play);
            }

            // Update the scene
            pSceneContext.GetState().Update(this.GetTime());

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_B))
            {
                SpriteBatch pBoxSprite = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                pBoxSprite.Enable();
            }

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_U))
            {
                SpriteBatch pBoxSprite = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                pBoxSprite.Disable();
            }
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------

        public override void Draw()
        {

            pSceneContext.GetState().Draw();

        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            Simulation.Destroy();
            GhostMan.Destroy();
            FontMan.Destroy();
            GlyphMan.Destroy();
            ColPairMan.Destroy();
            GameObjectNodeMan.Destroy();
            SpriteGameProxyMan.Destroy();
            TimerEventMan.Destroy();
            SpriteBoxMan.Destroy();
            SpriteBatchMan.Destroy();
            SpriteGameMan.Destroy();
            ImageMan.Destroy();
            TextureMan.Destroy();
        }

        public override void DisplayHeader()
        {
            Console.Write(this.Header());
        }

        public override void DisplayFooter()
        {
            Console.Write(this.Footer());
        }

        public void Reset()
        {
            ScoreManager.Reset();
            Ship pShip = ShipMan.GetShip();
            Ship.shipLife = 3;
            ScenePlay.Level = 1;
            ShipMan.Destroy();
            this.UnLoadContent();
            this.LoadContent();

             AlienGrid.SetHitLeft(true);

            Font scoreFont = FontMan.Find(Font.Name.ScoreNum);
            if (scoreFont != null)
            {
                scoreFont.UpdateMessage(ScoreManager.score.ToString());
            }

            Font highScoreFont = FontMan.Find(Font.Name.HighScoreNum);

            if (highScoreFont != null)
            {
                highScoreFont.UpdateMessage(ScoreManager.highScore.ToString());
            }

        }
    }
}

// --- End of File ---
