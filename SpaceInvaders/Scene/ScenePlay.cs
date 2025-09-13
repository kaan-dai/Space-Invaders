//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;
using System.Windows.Shapes;

namespace SE456
{
    public class ScenePlay : SceneState
    {
        IrrKlang.ISoundEngine pSndEngine = null;
        Drum pDrum;
        public ScenePlay()
        {
            this.Initialize();
        }
        public override void Handle()
        {

        }


        public override void Initialize()
        {

            this.poSpriteBatchMan = new SpriteBatchMan(5, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poGameObjectNodeMan = new GameObjectNodeMan(3, 1);
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);

            this.poGhostMan = new GhostMan(3, 1);
            GhostMan.SetActive(this.poGhostMan);
            //------------------------------------------------------
            // Sound Experiment
            //------------------------------------------------------

            // start up the engine
            pSndEngine = new IrrKlang.ISoundEngine();
            Debug.Assert(pSndEngine != null);

            // Load Sounds
            IrrKlang.ISoundSource pSndVader0 = pSndEngine.AddSoundSourceFromFile("fastinvader1.wav");
            IrrKlang.ISoundSource pSndVader1 = pSndEngine.AddSoundSourceFromFile("fastinvader2.wav");
            IrrKlang.ISoundSource pSndVader2 = pSndEngine.AddSoundSourceFromFile("fastinvader3.wav");
            IrrKlang.ISoundSource pSndVader3 = pSndEngine.AddSoundSourceFromFile("fastinvader4.wav");
            IrrKlang.ISoundSource pSndAlienDestroy = pSndEngine.AddSoundSourceFromFile("shoot.wav");
            IrrKlang.ISoundSource pSndShipShoot = pSndEngine.AddSoundSourceFromFile("invaderkilled.wav");
            IrrKlang.ISoundSource pSndShipDeath = pSndEngine.AddSoundSourceFromFile("explosion.wav");
            IrrKlang.ISoundSource pSndUfoHighPitch = pSndEngine.AddSoundSourceFromFile("ufo_highpitch.wav");
            IrrKlang.ISoundSource pSndShipLowPitch = pSndEngine.AddSoundSourceFromFile("ufo_lowpitch.wav");

            pSndEngine.SoundVolume = 0.0f;
            pSndEngine.Play2D(pSndVader0, false, false, false);

            //-----------------------------------
            // Load the Textures & Font
            //-----------------------------------
            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.t.azul");

            GlyphMan.AddXml("Consolas36pt.xml", Glyph.Name.SpaceInvaders, Texture.Name.SpaceInvaders);

            GlyphMan.Add(Glyph.Name.SpaceInvaders, 65, Texture.Name.SpaceInvaders, 3, 36, 5, 8); // .A
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 66, Texture.Name.SpaceInvaders, 11, 36, 5, 8); // .B
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 67, Texture.Name.SpaceInvaders, 19, 36, 5, 8); // .C
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 68, Texture.Name.SpaceInvaders, 27, 36, 5, 8); // .D
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 69, Texture.Name.SpaceInvaders, 35, 36, 5, 8); // .E
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 70, Texture.Name.SpaceInvaders, 43, 36, 5, 8); // .F
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 71, Texture.Name.SpaceInvaders, 51, 36, 5, 8); // .G
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 72, Texture.Name.SpaceInvaders, 59, 36, 5, 8); // .H
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 73, Texture.Name.SpaceInvaders, 67, 36, 5, 8); // .I
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 74, Texture.Name.SpaceInvaders, 75, 36, 5, 8); // .J
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 75, Texture.Name.SpaceInvaders, 83, 36, 5, 8); // .K
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 76, Texture.Name.SpaceInvaders, 91, 36, 5, 8); // .L
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 77, Texture.Name.SpaceInvaders, 99, 36, 5, 8); // .M
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 78, Texture.Name.SpaceInvaders, 3, 46, 5, 8); // .N
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 79, Texture.Name.SpaceInvaders, 11, 46, 5, 8); // .O
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 80, Texture.Name.SpaceInvaders, 19, 46, 5, 8); // .P
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 81, Texture.Name.SpaceInvaders, 27, 46, 5, 8); // .Q
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 82, Texture.Name.SpaceInvaders, 35, 46, 5, 8); // .R
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 83, Texture.Name.SpaceInvaders, 43, 46, 5, 8); // .S
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 84, Texture.Name.SpaceInvaders, 51, 46, 5, 8); // .T
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 85, Texture.Name.SpaceInvaders, 59, 46, 5, 8); // .U
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 86, Texture.Name.SpaceInvaders, 67, 46, 5, 8); // .V
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 87, Texture.Name.SpaceInvaders, 75, 46, 5, 8); // .W
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 88, Texture.Name.SpaceInvaders, 83, 46, 5, 8); // .X
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 89, Texture.Name.SpaceInvaders, 91, 46, 5, 8); // .Y
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 90, Texture.Name.SpaceInvaders, 99, 46, 5, 8); // .Z
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 48, Texture.Name.SpaceInvaders, 3, 56, 5, 8); // 0
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 49, Texture.Name.SpaceInvaders, 11, 56, 5, 8); // 1
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 50, Texture.Name.SpaceInvaders, 19, 56, 5, 8); // 2
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 51, Texture.Name.SpaceInvaders, 27, 56, 5, 8); // 3
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 52, Texture.Name.SpaceInvaders, 35, 56, 5, 8); // 4
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 53, Texture.Name.SpaceInvaders, 43, 56, 5, 8); // 5
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 54, Texture.Name.SpaceInvaders, 51, 56, 5, 8); // 6
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 55, Texture.Name.SpaceInvaders, 59, 56, 5, 8); // 7
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 56, Texture.Name.SpaceInvaders, 67, 56, 5, 8); // 8
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 57, Texture.Name.SpaceInvaders, 75, 56, 5, 8); // 9
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 60, Texture.Name.SpaceInvaders, 83, 56, 5, 8); // <
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 62, Texture.Name.SpaceInvaders, 91, 56, 5, 8); // >
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 32, Texture.Name.SpaceInvaders, 99, 56, 1, 8); // Space
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 61, Texture.Name.SpaceInvaders, 107, 56, 5, 8); // =
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 42, Texture.Name.SpaceInvaders, 115, 56, 5, 8); // *
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 63, Texture.Name.SpaceInvaders, 123, 56, 5, 8); // ?
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 45, Texture.Name.SpaceInvaders, 131, 56, 5, 8); // -

            //-----------------------------------
            // Create Images
            //-----------------------------------

            ImageMan.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageMan.Add(Image.Name.Ship, Texture.Name.SpaceInvaders, 3, 14, 13, 8);
            ImageMan.Add(Image.Name.Missile, Texture.Name.SpaceInvaders, 3, 29, 1, 4);
            ImageMan.Add(Image.Name.BombZigZagA, Texture.Name.SpaceInvaders, 24, 26, 3, 7);
            ImageMan.Add(Image.Name.BombZigZagB, Texture.Name.SpaceInvaders, 36, 26, 3, 7);
            ImageMan.Add(Image.Name.BombDaggerA, Texture.Name.SpaceInvaders, 42, 27, 3, 6);
            ImageMan.Add(Image.Name.BombDaggerB, Texture.Name.SpaceInvaders, 60, 27, 3, 6);
            ImageMan.Add(Image.Name.BombCrossA, Texture.Name.SpaceInvaders, 48, 27, 3, 6);
            ImageMan.Add(Image.Name.BombCrossB, Texture.Name.SpaceInvaders, 54, 27, 3, 6);
            ImageMan.Add(Image.Name.BombStraight, Texture.Name.SpaceInvaders, 66, 26, 3, 6);
            ImageMan.Add(Image.Name.Brick_LeftTop0, Texture.Name.SpaceInvaders, 114, 31, 7, 4);
            ImageMan.Add(Image.Name.Brick_RightTop1, Texture.Name.SpaceInvaders, 128, 31, 8, 4);
            ImageMan.Add(Image.Name.Brick_LeftBottom, Texture.Name.SpaceInvaders, 114, 43, 7, 4);
            ImageMan.Add(Image.Name.Brick_RightBottom, Texture.Name.SpaceInvaders, 128, 43, 8, 4);
            ImageMan.Add(Image.Name.Brick, Texture.Name.SpaceInvaders, 120, 35, 7, 4);
            ImageMan.Add(Image.Name.AlienDestroy, Texture.Name.SpaceInvaders, 83, 3, 13, 8);
            ImageMan.Add(Image.Name.BombDestroy, Texture.Name.SpaceInvaders, 7, 25, 8, 7);
            ImageMan.Add(Image.Name.ShipDeath1, Texture.Name.SpaceInvaders, 20, 14, 15, 8);
            ImageMan.Add(Image.Name.ShipDeath2, Texture.Name.SpaceInvaders, 38, 14, 16, 8);
            ImageMan.Add(Image.Name.UFO, Texture.Name.SpaceInvaders, 99, 4, 16, 7);
            ImageMan.Add(Image.Name.UFODestroy, Texture.Name.SpaceInvaders, 118, 3, 21, 8);



            //----------------------------------
            // Create Sprites
            //----------------------------------

            // --- GameObjects ---
            Azul.Color Green = new Azul.Color(0,1,0);
            Azul.Color Red = new Azul.Color(1, 0, 0);


            SpriteGameMan.Add(SpriteGame.Name.Squid, Image.Name.SquidA, 0, 0, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.Crab, Image.Name.CrabA, 0, 0, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 0, 0, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.Missile, Image.Name.Missile, 0, 0, 3, 12);
            SpriteGameMan.Add(SpriteGame.Name.Ship, Image.Name.Ship, 0, 0, 39, 24);
            SpriteGameMan.Add(SpriteGame.Name.ReservedShip, Image.Name.Ship, 0, 0, 39, 24).SwapColor(Green);
            SpriteGameMan.Add(SpriteGame.Name.BombZigZag, Image.Name.BombZigZagA, 0, 0, 6, 18);
            SpriteGameMan.Add(SpriteGame.Name.BombDagger, Image.Name.BombDaggerA, 0, 0, 6, 18);
            SpriteGameMan.Add(SpriteGame.Name.BombCross, Image.Name.BombCrossA, 0, 0, 6, 18);
            SpriteGameMan.Add(SpriteGame.Name.BombStraight, Image.Name.BombStraight, 0, 0, 6, 18);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftTop0, Image.Name.Brick_LeftTop0, 0, 0, 30, 15).SwapColor(Green);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightTop1, Image.Name.Brick_RightTop1, 0, 0, 30, 15).SwapColor(Green);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftBottom, Image.Name.Brick_LeftBottom, 0, 0, 30, 15).SwapColor(Green);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightBottom, Image.Name.Brick_RightBottom, 0, 0, 30, 15).SwapColor(Green);
            SpriteGameMan.Add(SpriteGame.Name.Brick, Image.Name.Brick, 0, 0, 30, 15).SwapColor(Green);
            SpriteGameMan.Add(SpriteGame.Name.ShipDeath1, Image.Name.ShipDeath1, 0, 0, 39, 24);
            SpriteGameMan.Add(SpriteGame.Name.ShipDeath2, Image.Name.ShipDeath1, 0, 0, 39, 24);
            SpriteGameMan.Add(SpriteGame.Name.UFO, Image.Name.UFO, 0, 0, 39, 25).SwapColor(Red);


            // --- BoxSprites ---


            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------


            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts, 300);
            SpriteBatch pSB_Aliens = SpriteBatchMan.Add(SpriteBatch.Name.Aliens, 500);
            SpriteBatch pSB_Bombs = SpriteBatchMan.Add(SpriteBatch.Name.Bombs, 650);
            SpriteBatch pSB_Shields = SpriteBatchMan.Add(SpriteBatch.Name.Shields, 700);
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes, 800);

            pSB_Box.Disable();



            //-------------------------------------------------------
            // Create Font
            //-------------------------------------------------------

            Font pFont;
            pFont = FontMan.Add(Font.Name.Score1, SpriteBatch.Name.Texts, "S C O R E < 1 >", Glyph.Name.SpaceInvaders, 26, 740);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, "H I - S C O R E", Glyph.Name.SpaceInvaders, 265, 740);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.Score2, SpriteBatch.Name.Texts, "S C O R E < 2 >", Glyph.Name.SpaceInvaders, 503, 740);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.Wave, SpriteBatch.Name.Texts, "0", Glyph.Name.SpaceInvaders, 557, 700);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.HighScoreNum, SpriteBatch.Name.Texts, ScoreManager.highScore.ToString(), Glyph.Name.SpaceInvaders, 325, 700);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.ScoreNum, SpriteBatch.Name.Texts, ScoreManager.score.ToString(), Glyph.Name.SpaceInvaders, 57, 700);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.Life, SpriteBatch.Name.Texts, Ship.shipLife.ToString(), Glyph.Name.SpaceInvaders, 25, 30);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.Credits, SpriteBatch.Name.Texts, "C R E D I T", Glyph.Name.SpaceInvaders, 485, 30);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            pFont = FontMan.Add(Font.Name.CreditsNum, SpriteBatch.Name.Texts, "0 0", Glyph.Name.SpaceInvaders, 608, 30);
            pFont.poSpriteFont.sx = 3.0f;
            pFont.poSpriteFont.sy = 3.0f;

            //-------------------------------------------------------
            // Create Input
            //-------------------------------------------------------

            if (!isGameOver)
            {
                InputSubject pInputSubject;
                pInputSubject = InputMan.GetArrowRightSubject();
                pInputSubject.Attach(new MoveRightObserver());

                pInputSubject = InputMan.GetArrowLeftSubject();
                pInputSubject.Attach(new MoveLeftObserver());

                pInputSubject = InputMan.GetSpaceSubject();
                pInputSubject.Attach(new ShootObserver());

                isGameOver = true;
            }


            Simulation.SetState(Simulation.State.Realtime);




            //-------------------------------------------------------
            // Create Ship
            //-------------------------------------------------------

            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, SpriteGame.Name.Ship, 0.0f, 0.0f);
            GameObjectNodeMan.Attach(pShipRoot);
            ShipMan.Create();

            for (int i = 0; i < Ship.shipLife; i++)
            {
                pSB_Aliens.Attach(SpriteGameMan.Add(SpriteGame.Name.ReservedShip, Image.Name.Ship, 88 + 50 * i, 33, 39, 24, Green));
            }



            //-------------------------------------------------------
            // Create Missile
            //-------------------------------------------------------

            MissileGroup pMissileGroup = new MissileGroup();
            pMissileGroup.ActivateSprite(pSB_Aliens);
            pMissileGroup.ActivateCollisionSprite(pSB_Box);

            GameObjectNodeMan.Attach(pMissileGroup);

            pMissileGroup.Print();

            //---------------------------------------------------------------------------------------------------------
            // Shield 
            //---------------------------------------------------------------------------------------------------------

            GameObjectNodeMan.Attach(new ShieldRoot(GameObject.Name.ShieldRoot, SpriteGame.Name.NullObject, 0, 0));

            ShieldFactory SF = new ShieldFactory();
            ShieldRoot pShieldRoot = (ShieldRoot)GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);

            for (int i = 0; i < 4; i++)
            {
                ShieldFactory.CreateSingleShield(100.0f + 140 * i);
            }

            //---------------------------------------------------------------------------------------------------------
            // Create Walls
            //---------------------------------------------------------------------------------------------------------

            // Wall Root
            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Box);
            pWallGroup.ActivateCollisionSprite(pSB_Box);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, SpriteGame.Name.NullObject, 664, 350, 24, 580);
            pWallRight.ActivateCollisionSprite(pSB_Box);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, SpriteGame.Name.NullObject, 12, 350, 24, 580);
            pWallLeft.ActivateCollisionSprite(pSB_Box);

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, SpriteGame.Name.NullObject, 337, 720, 672, 103);
            pWallTop.ActivateCollisionSprite(pSB_Box);

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, SpriteGame.Name.NullObject, 337, 50, 672, 1);
            pWallBottom.ActivateCollisionSprite(pSB_Box);

            // Add to the composite the children
            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);

            GameObjectNodeMan.Attach(pWallGroup);


            //---------------------------------------------------------------------------------------------------------
            // Create Bumpers
            //---------------------------------------------------------------------------------------------------------

            BumperRoot pBumperRoot = new BumperRoot(GameObject.Name.BumperRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Box);

            BumperRight pBumperRight = new BumperRight(GameObject.Name.BumperRight, SpriteGame.Name.NullObject, 647, 100, 50, 100);
            pBumperRight.ActivateCollisionSprite(pSB_Box);

            BumperLeft pBumperLeft = new BumperLeft(GameObject.Name.BumperLeft, SpriteGame.Name.NullObject, 25, 100, 50, 100);
            pBumperLeft.ActivateCollisionSprite(pSB_Box);

            // Add to the composite the children
            pBumperRoot.Add(pBumperRight);
            pBumperRoot.Add(pBumperLeft);

            GameObjectNodeMan.Attach(pBumperRoot);

            //---------------------------------------------------------------------------------------------------------
            // Create Aliens
            //---------------------------------------------------------------------------------------------------------

            AlienFactory AF = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);

            GameObject pGrid = AF.Create(GameObject.Name.AlienGrid, AlienCategory.Type.AlienGrid);
            pGrid.ActivateCollisionSprite(pSB_Box);

            for (int i = 0; i < 11; i++)
            {
                GameObject pCol = AF.Create(GameObject.Name.AlienColumn, AlienCategory.Type.AlienColumn);
                pCol.ActivateCollisionSprite(pSB_Box);

                pCol.Add(AF.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, 86.0f + i * 50.0f, 400.0f));
                pCol.Add(AF.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, 86.0f + i * 50.0f, 400.0f + 50.0f));
                pCol.Add(AF.Create(GameObject.Name.Crab, AlienCategory.Type.Crab, 86.0f + i * 50.0f, 400.0f + 100.0f));
                pCol.Add(AF.Create(GameObject.Name.Crab, AlienCategory.Type.Crab, 86.0f + i * 50.0f, 400.0f + 150.0f));
                pCol.Add(AF.Create(GameObject.Name.Squid, AlienCategory.Type.Squid, 86.0f + i * 50.0f, 400.0f + 200.0f));

                pGrid.Add(pCol);

            }

            GameObjectNodeMan.Attach(pGrid);

            //---------------------------------------------------------------------------------------------------------
            // Bomb
            //---------------------------------------------------------------------------------------------------------

            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(pSB_Box);

            GameObjectNodeMan.Attach(pBombRoot);

            Random bombRandom = new Random();

            pGrid = GameObjectNodeMan.Find(GameObject.Name.AlienGrid);
            Debug.Assert(pGrid != null);

            float initialDelay = ((float)bombRandom.NextDouble() * 1.5f + 0.5f) / ScenePlay.Level;

            TimerEventMan.Add(TimerEvent.Name.BombSpawn, new BombSpawnManagerCommand(pGrid, bombRandom), initialDelay);
            

            //---------------------------------------------------------------------------------------------------------
            // Create UFO
            //---------------------------------------------------------------------------------------------------------

            UFORoot pUFORoot = new UFORoot(GameObject.Name.UFORoot,SpriteGame.Name.NullObject, 0, 0);

            UFO pUFO = new UFO(GameObject.Name.UFO, SpriteGame.Name.UFO, -70, 650);

            pUFORoot.Add(pUFO);

            pUFORoot.ActivateSprite(pSB_Aliens);
            pUFORoot.ActivateCollisionSprite(pSB_Box);

            pUFO.ActivateSprite(pSB_Aliens);
            pUFO.ActivateCollisionSprite(pSB_Box);




            GameObjectNodeMan.Attach(pUFORoot);

            //-------------------------------------------------------
            // Animate Aliens and Move
            //-------------------------------------------------------

            float endSpeed = 12.0f + Level * 4.0f;
            float initialSpeed = 4.0f + Level * 4.0f;
            pDrum = new Drum((AlienGrid)pGrid, 0.7f, 0.05f, initialSpeed, endSpeed);
            pDrum.Update();

            //Squid
            SpriteAnimationCommand pAnimCmdSquid = new SpriteAnimationCommand(SpriteGame.Name.Squid, pDrum);
            pAnimCmdSquid.Attach(Image.Name.SquidA);
            pAnimCmdSquid.Attach(Image.Name.SquidB);
            TimerEventMan.Add(TimerEvent.Name.SpriteAnimation, pAnimCmdSquid, pDrum.GetBeat());

            //Crab
            SpriteAnimationCommand pAnimCmdCrab = new SpriteAnimationCommand(SpriteGame.Name.Crab, pDrum);
            pAnimCmdCrab.Attach(Image.Name.CrabA);
            pAnimCmdCrab.Attach(Image.Name.CrabB);
            TimerEventMan.Add(TimerEvent.Name.SpriteAnimation, pAnimCmdCrab, pDrum.GetBeat());

            //Octopus
            SpriteAnimationCommand pAnimCmdOctopus = new SpriteAnimationCommand(SpriteGame.Name.Octopus, pDrum);
            pAnimCmdOctopus.Attach(Image.Name.OctopusA);
            pAnimCmdOctopus.Attach(Image.Name.OctopusB);
            TimerEventMan.Add(TimerEvent.Name.SpriteAnimation, pAnimCmdOctopus, pDrum.GetBeat());

            //Move Grid
            GridMoveCommand pGridMoveCmd = new GridMoveCommand(pGrid, pDrum);
            TimerEventMan.Add(TimerEvent.Name.GridMove, pGridMoveCmd, pDrum.GetBeat());

            //Move Sound
            SoundMoveCommand pSoundMoveCmd = new SoundMoveCommand(pSndEngine, pSndVader0, pSndVader1, pSndVader2, pSndVader3, pDrum);
            TimerEventMan.Add(TimerEvent.Name.MoveSound, pSoundMoveCmd, pDrum.GetBeat());

            //Move UFO
            UFOMoveCommand pUFOCmd = new UFOMoveCommand(pSndEngine, pSndUfoHighPitch, pSndShipLowPitch);
            TimerEventMan.Add(TimerEvent.Name.UFOMove, pUFOCmd, new Random().Next(20,30));



            //-----------------------------------------------------------------
            // Print Test
            //-----------------------------------------------------------------

            Debug.WriteLine("-------------------");

            IteratorForwardComposite pFor = new IteratorForwardComposite(pGrid);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                pNode.DumpNode();

                pNode = pFor.Next();
            }

            //-----------------------------------------------------------------
            // ColPair 
            //-----------------------------------------------------------------
            ColPair pColPair;

            //AlienGrid vs Walls
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Wall, pGrid, pWallGroup);
            Debug.Assert(pColPair != null);

            pColPair.Attach(new GridObserver());

            //Missle vs Walls
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallGroup);
            Debug.Assert(pColPair != null);

            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());

            //Missle vs AlienGrid
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Alien, pMissileGroup, pGrid);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new SndObserver(pSndEngine, pSndAlienDestroy));
            pColPair.Attach(new RemoveAlienObserver());
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());

            // Missile vs Shield
            pColPair = ColPairMan.Add(ColPair.Name.Misslie_Shield, pMissileGroup, pShieldRoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver());

            // Missile vs Bomb
            pColPair = ColPairMan.Add(ColPair.Name.Missle_Bomb, pMissileGroup, pBombRoot);
            pColPair.Attach(new SndObserver(pSndEngine, pSndAlienDestroy));
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());

            //Missile vs UFO
            pColPair = ColPairMan.Add(ColPair.Name.Missile_UFO, pMissileGroup, pUFORoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());
            pColPair.Attach(new RemoveUFOObserver());
            pColPair.Attach(new SndObserver(pSndEngine, pSndAlienDestroy));

            //Bumper vs Ship
            pColPair = ColPairMan.Add(ColPair.Name.Bumper_Ship, pBumperRoot, pShipRoot);
            pColPair.Attach(new ShipMoveObserver());

            // Bomb vs Bottom
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
            pColPair.Attach(new RemoveBombObserver());

            // Bomb vs Shield
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            //Bomb vs Ship
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Ship, pBombRoot, pShipRoot);
            pColPair.Attach(new SndObserver(pSndEngine, pSndShipDeath));
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new ShipDeathObserver());


        }

        public override void Update(float systemTime)
        {

            AlienGrid pGrid = (AlienGrid)GameObjectNodeMan.Find(GameObject.Name.AlienGrid);
            GameObject pChild = (GameObject)IteratorForwardComposite.GetChild(pGrid);

            if (pChild == null)
            { 

                SceneContext.nextLevel();
            }

            // Single Step, Free running...
            Simulation.Update(systemTime);

            pSndEngine.Update();

            // Input
            InputMan.Update();

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Fire off the timer events
                TimerEventMan.Update(Simulation.GetTotalTime());

                // Do the collision checks
                ColPairMan.Process();

                // walk through all objects and push to flyweight
                GameObjectNodeMan.Update();

                // Delete any objects here...
                DelayedObjectMan.Process();
            }
        }
        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }
        public override void Entering()
        {
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);
            GhostMan.SetActive(this.poGhostMan);

            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);
        }
        public override void Leaving()
        {
            // Need a better way to do this
            this.TimeAtPause = GlobalTimer.GetTime();
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public GameObjectNodeMan poGameObjectNodeMan;
        public GhostMan poGhostMan;
        public Ship ship;
        public static int Level = 1;
        readonly Random pRandom = new Random();
        public static bool isGameOver = false;



    }
}
// --- End of File ---
