using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State currentState;

        public void SwitchState(State newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
        void Update()
        {
            currentState?.Tick(Time.deltaTime);
        }

    }

}
