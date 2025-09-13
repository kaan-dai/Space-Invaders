using System;
using System.Diagnostics;

namespace SE456
{
    public class ShipDeathCommand : Command
    {
        private Ship pShip;

        public ShipDeathCommand(Ship ship)
        {
            Debug.Assert(ship != null);
            this.pShip = ship;
        }

        public override void Execute(float deltaTime)
        {
            pShip.SetSpriteNormal();

            pShip.SetState(ShipMan.MissileState.Ready);
            pShip.SetState(ShipMan.MoveState.MoveBoth);

        }
    }
}
