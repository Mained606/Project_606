using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public CharacterController Controller { get; private set; }
        [field: SerializeField] public ForceReciver ForceReciver { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Targeter Targeter { get; private set; }
        [field: SerializeField] public float FreeLookMovenmentSpeed { get; private set; }
        [field: SerializeField] public float TargetingMovenmentSpeed { get; private set; }
        [field: SerializeField] public float RotationDamping { get; private set; }
        [field: SerializeField] public Attack[] Attacks { get; private set; }

        

        public Transform MainCameraTransform {get; private set;}

        void Start()
        {
            MainCameraTransform = Camera.main.transform;
            
            SwitchState(new PlayerFreeLookState(this));
        }
    }

}
