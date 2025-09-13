//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System.Diagnostics;

namespace SE456
{
    public class SceneOver : SceneState
    {
        public SceneOver()
        {
            this.Initialize();
        }
        public override void Handle()
        {

        }
        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poGameObjectNodeMan = new GameObjectNodeMan(3, 1);
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);

            this.poGhostMan = new GhostMan(3, 1);
            GhostMan.SetActive(this.poGhostMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts,300);

            Font pFont;
            pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "G A M E   O V E R", Glyph.Name.SpaceInvaders, 275, 500);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1, 1, 1);

            pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "H I G H - S C O R E", Glyph.Name.SpaceInvaders, 250, 400);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1, 1, 1);

            pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "P R E S S      Q      T O    R E S T A R T", Glyph.Name.SpaceInvaders, 190, 250);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1, 1, 1);


        }
        public override void Update(float systemTime)
        {
            GameObjectNodeMan.Update();
        }

        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }

        public override void Entering()
        {
            if (ScoreManager.score > ScoreManager.highScore)
            {
                ScoreManager.highScore = ScoreManager.score;
            }

            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);
            GhostMan.SetActive(this.poGhostMan);


            Font pFont = FontMan.Add(Font.Name.HighScoreNum, SpriteBatch.Name.Texts, ScoreManager.highScore.ToString(), Glyph.Name.SpaceInvaders, 325, 350);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1, 1, 1);


        }
        public override void Leaving()
        {
            // update SpriteBatchMan()
            this.TimeAtPause = TimerEventMan.GetCurrTime();
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public GameObjectNodeMan poGameObjectNodeMan;
        public GhostMan poGhostMan;


    }
}
// --- End of File ---
