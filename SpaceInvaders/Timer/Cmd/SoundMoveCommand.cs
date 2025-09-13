using System;
using System.Diagnostics;

namespace SE456
{
    class SoundMoveCommand : Command
    {
        public SoundMoveCommand(IrrKlang.ISoundEngine pEng,
                                IrrKlang.ISoundSource _pSnd0,
                                IrrKlang.ISoundSource _pSnd1,
                                IrrKlang.ISoundSource _pSnd2,
                                IrrKlang.ISoundSource _pSnd3,
                                Drum drum)
        {
            Debug.Assert(pEng != null);
            this.pSndEngine = pEng;
            this.pSnd0 = _pSnd0;
            this.pSnd1 = _pSnd1;
            this.pSnd2 = _pSnd2;
            this.pSnd3 = _pSnd3;
            this.count = 0;
            Debug.Assert(drum != null);
            this.pDrum = drum;
        }
            
        public override void Execute(float deltaTime)
        {
            if (pDrum != null)
                pDrum.Update();

            pSndEngine.SoundVolume = 0.2f;
            switch (count)
            {
                case 0:
                    pSndEngine.Play2D(pSnd0, false, false, false);
                    break;
                case 1:
                    pSndEngine.Play2D(pSnd1, false, false, false);
                    break;
                case 2:
                    pSndEngine.Play2D(pSnd2, false, false, false);
                    break;
                case 3:
                    pSndEngine.Play2D(pSnd3, false, false, false);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            this.count++;
            if (count > 3)
            {
                this.count = 0;
            }

            if (!pDrum.IsEmpty())
            {
                TimerEventMan.Add(TimerEvent.Name.MoveSound, this, pDrum.GetBeat());
            }

           
        }

        //----------Data------------
        private IrrKlang.ISoundEngine pSndEngine;
        private IrrKlang.ISoundSource pSnd0;
        private IrrKlang.ISoundSource pSnd1;
        private IrrKlang.ISoundSource pSnd2;
        private IrrKlang.ISoundSource pSnd3;
        private int count;
        private Drum pDrum;
    }
}