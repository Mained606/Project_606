using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mained_606
{
    public class InputReader : MonoBehaviour, Controls.IPlayerActions
    {
        public Vector2 MoventValue { get; private set; }
        public event Action JumpEvent;
        public event Action DodgeEvent;
        private Controls controls;
        void Start()
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);

            controls.Player.Enable();
        }

        private void OnDestroy()
        {
            controls.Player.Disable();

        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            JumpEvent?.Invoke();
        }

        public void OnDodge(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            DodgeEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoventValue = context.ReadValue<Vector2>();

        }
    }

}
