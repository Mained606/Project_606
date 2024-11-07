using System.Collections.Generic;
using UnityEngine;

namespace Mained_606
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private Collider myCollider;

        private int damage;

        private List<Collider> alreadyColliderWith = new List<Collider> ();

        private void OnEnable()
        {
            alreadyColliderWith.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == myCollider) { return; }

            if(alreadyColliderWith.Contains(other)) { return; }

            alreadyColliderWith.Add(other);

            if(other.TryGetComponent<Health>(out Health health))
            {
                health.DealDamage(damage);
            }
        }

        public void SetAttack(int damage)
        {
            this.damage = damage;
        }
    }
}
