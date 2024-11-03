using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public class ForceReciver : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        private float verticalVelocity;

        public Vector3 Movement => Vector3.up * verticalVelocity;

        void Update()
        {
            if (verticalVelocity < 0f &&controller.isGrounded)
            {
                verticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }
        }
    }

}
