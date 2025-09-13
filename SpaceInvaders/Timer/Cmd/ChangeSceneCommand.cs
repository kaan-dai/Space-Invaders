using System;
using System.Diagnostics;

namespace SE456
{
    class ChangeSceneCommand : Command
    {
        public ChangeSceneCommand(SceneContext.Scene nextState)
        {
            this.nextState = nextState;
        }

        public override void Execute(float deltaTime)
        {

            SceneContext.current.SetState(nextState);
        }

        // Data: ---------------

        private SceneContext.Scene nextState;
    }

}