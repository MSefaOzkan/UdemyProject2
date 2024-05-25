﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 3;
        [SerializeField] private int _currentHealth = 0;

        public bool isDead => _currentHealth < 1;
        public event System.Action OnHealthChanged;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeHit(Damage damage)
        {
            if (isDead) return;
            _currentHealth -= damage.HitDamage;
            
            OnHealthChanged?.Invoke();
        }
    }
}

