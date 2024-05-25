using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int _damage;

        public int HitDamage => _damage;

        public void HitTarget(Health health)
        {
            health.TakeHit(this);
        }
    }
}
