﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        private TextMeshProUGUI _healthText;

        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        public void WriteHealth(int currentHealth, int maxHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }
}

