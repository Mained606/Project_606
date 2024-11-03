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
        protected void Move(Vector3 motion, float deltaTime)
        {
            stateMachine.Controller.Move((motion + stateMachine.ForceReciver.Movement) * deltaTime);
        }

        protected void FaceTarget()
        {
            // 타겟이 있는지 확인. 없으면 리턴
            if(stateMachine.Targeter.CurrentTarget == null) {return;}

            Vector3 lookPos = stateMachine.Targeter.CurrentTarget.transform.position - stateMachine.transform.position;
            lookPos.y = 0f;

            stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }

}
