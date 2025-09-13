//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class ShipMissileReady : ShipMissileState
    {
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipMan.MissileState.Flying);
        }

        public override void ShootMissile(Ship pShip)
        {
            pSndEngine = new IrrKlang.ISoundEngine();
            IrrKlang.ISoundSource pSndShipShoot = pSndEngine.AddSoundSourceFromFile("invaderkilled.wav");
            pSndEngine.SoundVolume = 0.3f;
            pSndEngine.Play2D(pSndShipShoot, false, false, false);


            Missile pMissile = ShipMan.ActivateMissile();
            pMissile.SetPos(pShip.x, pShip.y + 20);

            this.Handle(pShip);
        }

        IrrKlang.ISoundEngine pSndEngine = null;

    }
}// --- End of File ---
