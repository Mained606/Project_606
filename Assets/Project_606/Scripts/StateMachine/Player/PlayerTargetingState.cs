using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public class PlayerTargetingState : PlayerBaseState
    {
        private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");

        public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) {}
        public override void Enter()
        {
            stateMachine.InputReader.CancelEvent += OnCancel;

            stateMachine.Animator.Play(TargetingBlendTreeHash);
        }

        public override void Tick(float deltaTime)
        {
            if(stateMachine.Targeter.CurrentTarget == null)
            {
                stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
                return;
            }

            Vector3 movement = CalculatMovement();
            
            Move(movement * stateMachine.TargetingMovenmentSpeed, deltaTime);

            FaceTarget();
        }

        public override void Exit()
        {
            stateMachine.InputReader.CancelEvent -= OnCancel;
        }

        private void OnCancel()
        {
            stateMachine.Targeter.Cancel();

            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }

        private Vector3 CalculatMovement()
        {
            Vector3 movement = new Vector3();

            movement += stateMachine.transform.right * stateMachine.InputReader.MovementValue.x;
            movement += stateMachine.transform.forward * stateMachine.InputReader.MovementValue.y;

            return movement;
        }
    }

}
