using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Mained_606
{
    public class PlayerTestState : PlayerBaseState
    {
        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            Vector3 movement = new Vector3();
            movement.x = stateMachine.InputReader.MoventValue.x;
            movement.y = 0f;
            movement.z = stateMachine.InputReader.MoventValue.y;

            stateMachine.transform.Translate(movement * deltaTime);

            Debug.Log(stateMachine.InputReader.MoventValue);
        }

        private void OnJump()
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));

        }
    }

}
