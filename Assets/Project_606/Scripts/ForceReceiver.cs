using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public class ForceReciver : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private float drag = 0.3f;


        private Vector3 dampingVelocity;
        private Vector3 impact;
        private float verticalVelocity;

        public Vector3 Movement => impact + Vector3.up * verticalVelocity;

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

            impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);
        }

        public void AddForce(Vector3 force)
        {
            impact += force;
        }
    }
}
