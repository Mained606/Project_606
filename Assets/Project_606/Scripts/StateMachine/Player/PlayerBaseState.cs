using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine stateMachine;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }

}
