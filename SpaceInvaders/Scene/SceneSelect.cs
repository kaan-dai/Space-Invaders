//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System.Diagnostics;

namespace SE456
{
    public class SceneSelect : SceneState
    {
        public SceneSelect()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            Debug.WriteLine("Handle");
        }
        public override void Initialize()
        {
            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.t.azul");

            ImageMan.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.UFO, Texture.Name.SpaceInvaders, 99, 4, 16, 7);


            SpriteGameMan.Add(SpriteGame.Name.Squid, Image.Name.SquidA, 0, 0, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.Crab, Image.Name.CrabB, 0, 0, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 0, 0, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.UFO, Image.Name.UFO, 0, 0, 39, 25);

            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poGameObjectNodeMan = new GameObjectNodeMan(3, 1);
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);

            this.poGhostMan = new GhostMan(3, 1);
            GhostMan.SetActive(this.poGhostMan);

            SpriteBatch pSB_Aliens = SpriteBatchMan.Add(SpriteBatch.Name.Aliens, 400);
            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts, 500);

            pSB_Aliens.Attach(SpriteGameMan.Add(SpriteGame.Name.Squid, Image.Name.SquidA, 225,150, 24, 25));
            pSB_Aliens.Attach(SpriteGameMan.Add(SpriteGame.Name.Crab, Image.Name.CrabB, 225, 200, 28, 25));
            pSB_Aliens.Attach(SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 225, 250, 36, 25));
            pSB_Aliens.Attach(SpriteGameMan.Add(SpriteGame.Name.UFO, Image.Name.UFO, 225, 300, 39, 25));


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

        private void LoadOnEntry()
        {

            Font pFont;
            pFont = FontMan.Add(Font.Name.SelectSceneMessage, SpriteBatch.Name.Texts, "A T T R A C T    M O D E", Glyph.Name.SpaceInvaders, 250, 650);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.SelectSceneMessage, SpriteBatch.Name.Texts, "P R E S S      P      T O    P L A Y", Glyph.Name.SpaceInvaders, 225, 550);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.SelectSceneMessage, SpriteBatch.Name.Texts, "S P A C E  I N V A D E R S", Glyph.Name.SpaceInvaders, 225, 500);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.SelectSceneMessage, SpriteBatch.Name.Texts, "=  ?    M Y S T E R Y", Glyph.Name.SpaceInvaders, 275, 300);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.SelectSceneMessage, SpriteBatch.Name.Texts, "=  3 0    P O I N T S", Glyph.Name.SpaceInvaders, 275, 250);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.SelectSceneMessage, SpriteBatch.Name.Texts, "=  2 0    P O I N T S", Glyph.Name.SpaceInvaders, 275, 200);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.SelectSceneMessage, SpriteBatch.Name.Texts, "= 10    P O I N T S", Glyph.Name.SpaceInvaders, 275, 150);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;
            pFont.SetColor(1.0f, 1.0f, 1.0f);


            //TimedCharacterFactory.Install("PLAY", 2.0f, 0.30f, 340, 500, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("SPACE  INVADERS", 4.0f, 0.10f, 230, 400, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("= ? MYSTERY", 7.0f, 0.10f, 360, 300, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("= 30 POINTS", 10.0f, 0.10f, 360, 250, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("= 20 POINTS", 13.0f, 0.10f, 360, 200, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("= 10 POINTS", 16.0f, 0.10f, 360, 150, 0.2f, 0.8f, 0.2f);

        }
        public override void Entering()
        {
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);
            GhostMan.SetActive(this.poGhostMan);
            this.LoadOnEntry();
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
