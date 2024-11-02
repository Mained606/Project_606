using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        void Start()
        {
            SwitchState(new PlayerTestState(this));
        }
    }

}
