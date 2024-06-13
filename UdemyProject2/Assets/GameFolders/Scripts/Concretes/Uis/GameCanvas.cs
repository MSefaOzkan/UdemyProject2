using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _gamePlayObject;
        [SerializeField] private GameOverPanel _gameOverPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }

        private void HandleSceneChanged(bool isActive)
        {
            if (!isActive == _gamePlayObject.activeSelf) return;
            _gamePlayObject.gameObject.SetActive(isActive);
        }

        public void ShowGameOverPanel()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    }
}

