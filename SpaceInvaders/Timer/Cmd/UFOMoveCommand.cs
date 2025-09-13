using IrrKlang;
using System;
using System.Diagnostics;
using System.Windows;

namespace SE456
{
    class UFOMoveCommand : Command
    {
        public UFOMoveCommand(IrrKlang.ISoundEngine soundEngine = null, IrrKlang.ISoundSource sound1 = null, IrrKlang.ISoundSource sound2 = null)
        {
            this.UFORoot = (UFORoot)GameObjectNodeMan.Find(GameObject.Name.UFORoot);
            Debug.Assert(this.UFORoot != null);

            if(soundEngine == null) 
            {
                Debug.Assert(pSoundEngine != null);
            }
            else
            {
                pSoundEngine = soundEngine;
            }

            if (sound1 == null)
            {
                Debug.Assert(pSound1 != null);
            }
            else
            {
                pSound1 = sound1;
            }

            if (sound2 == null)
            {

                Debug.Assert(pSound2 != null);

            }
            else
            {
                pSound2 = sound2;

            }

            this.random = new Random();

            if (random.Next(0, 2) == 0)
            {
                this.currentSound = sound1;
            }
            else
            {
                this.currentSound = sound2;
            }
        }

        public override void Execute(float deltaTime)
        {

            switch (count)
            {
                case 0:
                    pSoundEngine.Play2D(currentSound, false, false, false);
                    count = 1;
                    break;
                case 5:
                    if (currentSound == pSound1)
                    {
                        count = 0;
                    }
                    else
                    {
                        count += 1;
                    }
                    break;
                case 60:
                    count = 0;
                    break;
                default:
                    count += 1;
                    break;
            }


            UFORoot.MoveUFOHorizontal();

            if (UFORoot.x < -60.0f || UFORoot.x > 730.0f)
            {
                isReady = false;
            }

            if (!isDestroyed && isReady)
            {
                TimerEventMan.Add(TimerEvent.Name.UFOMove, this, 0.01f);
            }
            else if (!isDestroyed)
            {

                if ((UFORoot.x <= -60.0f && UFORoot.deltaX <= 0) || (UFORoot.x >= 730.0f && UFORoot.deltaX >= 0))
                {

                    UFORoot.deltaX *= -1;
                }


                if (random.Next(0, 2) == 0)
                {
                    this.currentSound = pSound1;
                }
                else
                {
                    this.currentSound = pSound2;
                }

                TimerEventMan.Add(TimerEvent.Name.UFOMove, this, random.Next(20,30));
                            
                isReady = true;
            }
        }

        // -------------Data--------------

        public static bool isReady = true;
        public static bool isDestroyed = false;
        private Random random;

        private UFORoot UFORoot;
        private static IrrKlang.ISoundEngine pSoundEngine;
        private static IrrKlang.ISoundSource pSound1;
        private static IrrKlang.ISoundSource pSound2;
        private IrrKlang.ISoundSource currentSound;
        private int count = 0;


    }
}