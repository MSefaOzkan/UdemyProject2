﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
            GameManager.Instance.IncreaseScore();
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }

        private void HandleScoreChanged(int gemCount)
        {
            _scoreText.text = gemCount.ToString();
        }
    }
}

