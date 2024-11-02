using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public class PlayeyFreeLookState : PlayerBaseState
    {
        private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
        public PlayeyFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        private const float AnimatorDampTime = 0.1f;


        public override void Enter()
        {
            
        }


        public override void Tick(float deltaTime)
        {
            Vector3 movement = CalculateMovement();

            stateMachine.Controller.Move(movement * stateMachine.FreeLookMovenmentSpeed * deltaTime);
            
            // 이동 애니메이션
            if(stateMachine.InputReader.MovementValue == Vector2.zero)
            {
                stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
                return;
            }
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);

            //이동시 부드러운 회전 
            FaceMovementDirection(movement, deltaTime);
        }


        public override void Exit()
        {

        }

        //올바른 이동 방향 구하기
        private Vector3 CalculateMovement()
        {
            Vector3 forward = stateMachine.MainCameraTransform.forward;
            Vector3 right = stateMachine.MainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            return forward * stateMachine.InputReader.MovementValue.y +
                right * stateMachine.InputReader.MovementValue.x;

        }

        // 부드러운 회전 로직
        private void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            stateMachine.transform.rotation = Quaternion.Lerp(
                stateMachine.transform.rotation,
                Quaternion.LookRotation(movement),
                deltaTime * stateMachine.RotationDamping);
        }

    }

}
